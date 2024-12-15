using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace dotnet_winforms
{
    public partial class EmailForm : Form
    {
        private OpenFileDialog attachmentDialog;
        private string[] attachments = new string[5];
        private int attachmentCount = 0;

        public EmailForm()
        {
            InitializeComponent();
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBody.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            if (attachmentCount >= 5)
            {
                MessageBox.Show("You can only add up to 5 attachments.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            attachmentDialog = new OpenFileDialog();
            if (attachmentDialog.ShowDialog() == DialogResult.OK)
            {
                attachments[attachmentCount] = attachmentDialog.FileName;
                lstAttachments.Items.Add(Path.GetFileName(attachmentDialog.FileName));
                attachmentCount++;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(txtFrom.Text);
                mail.To.Add(txtTo.Text);
                if (!string.IsNullOrWhiteSpace(txtCC.Text)) mail.CC.Add(txtCC.Text);
                if (!string.IsNullOrWhiteSpace(txtBCC.Text)) mail.Bcc.Add(txtBCC.Text);
                mail.Subject = txtSubject.Text;

                foreach (string attachment in attachments)
                {
                    if (attachment != null)
                    {
                        mail.Attachments.Add(new Attachment(attachment));
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtEmbedImage.Text) && File.Exists(txtEmbedImage.Text))
                {
                    LinkedResource inlineImage = new LinkedResource(txtEmbedImage.Text)
                    {
                        ContentId = "InlineImage"
                    };

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                        richTextBody.Rtf.Replace(@"{\field{\*\fldinst{ INCLUDEPICTURE ""cid:InlineImage""}}}", @"<img src='cid:InlineImage'/>"),
                        null, "text/html");

                    htmlView.LinkedResources.Add(inlineImage);
                    mail.AlternateViews.Add(htmlView);
                }
                else
                {
                    mail.Body = richTextBody.Rtf;
                    mail.IsBodyHtml = true;
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com") // Replace with your SMTP server
                {
                    Port = 587,
                    Credentials = new NetworkCredential(txtFrom.Text, txtPassword.Text),
                    EnableSsl = true
                };

                smtp.Send(mail);
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBody.SelectionFont != null)
            {
                Font currentFont = richTextBody.SelectionFont;
                FontStyle newStyle = richTextBody.SelectionFont.Style;

                if (currentFont.Style.HasFlag(style))
                {
                    newStyle &= ~style;
                }
                else
                {
                    newStyle |= style;
                }

                richTextBody.SelectionFont = new Font(currentFont, newStyle);
            }
        }
    }
}
