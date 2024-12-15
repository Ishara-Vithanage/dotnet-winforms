namespace dotnet_winforms
{
    partial class EmailForm
    {
        private RichTextBox richTextBody;
        private TextBox txtFrom, txtTo, txtCC, txtBCC, txtSubject, txtPassword, txtEmbedImage;
        private ListBox lstAttachments;
        private Button btnBold, btnItalic, btnColor, btnAddAttachment, btnSend;

        private void InitializeComponent()
        {
            this.richTextBody = new RichTextBox();
            this.txtFrom = new TextBox();
            this.txtTo = new TextBox();
            this.txtCC = new TextBox();
            this.txtBCC = new TextBox();
            this.txtSubject = new TextBox();
            this.txtPassword = new TextBox();
            this.txtEmbedImage = new TextBox();
            this.lstAttachments = new ListBox();
            this.btnBold = new Button();
            this.btnItalic = new Button();
            this.btnColor = new Button();
            this.btnAddAttachment = new Button();
            this.btnSend = new Button();

            this.SuspendLayout();

            // TextBox Configurations
            this.txtFrom.Location = new Point(100, 20);
            this.txtFrom.Width = 300;
            this.txtFrom.PlaceholderText = "From";

            this.txtTo.Location = new Point(100, 60);
            this.txtTo.Width = 300;
            this.txtTo.PlaceholderText = "To";

            this.txtCC.Location = new Point(100, 100);
            this.txtCC.Width = 300;
            this.txtCC.PlaceholderText = "CC";

            this.txtBCC.Location = new Point(100, 140);
            this.txtBCC.Width = 300;
            this.txtBCC.PlaceholderText = "BCC";

            this.txtSubject.Location = new Point(100, 180);
            this.txtSubject.Width = 300;
            this.txtSubject.PlaceholderText = "Subject";

            this.txtPassword.Location = new Point(420, 20);
            this.txtPassword.Width = 150;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Password";

            this.txtEmbedImage.Location = new Point(100, 460);
            this.txtEmbedImage.Width = 300;
            this.txtEmbedImage.PlaceholderText = "Path to embed image";

            // RichTextBox
            this.richTextBody.Location = new Point(100, 220);
            this.richTextBody.Size = new Size(470, 220);

            // ListBox for attachments
            this.lstAttachments.Location = new Point(420, 60);
            this.lstAttachments.Size = new Size(150, 100);

            // Buttons
            this.btnBold.Location = new Point(10, 220);
            this.btnBold.Text = "Bold";
            this.btnBold.Click += new EventHandler(this.btnBold_Click);

            this.btnItalic.Location = new Point(10, 260);
            this.btnItalic.Text = "Italic";
            this.btnItalic.Click += new EventHandler(this.btnItalic_Click);

            this.btnColor.Location = new Point(10, 300);
            this.btnColor.Text = "Color";
            this.btnColor.Click += new EventHandler(this.btnColor_Click);

            this.btnAddAttachment.Location = new Point(420, 180);
            this.btnAddAttachment.Text = "Add Attachment";
            this.btnAddAttachment.Click += new EventHandler(this.btnAddAttachment_Click);

            this.btnSend.Location = new Point(10, 500);
            this.btnSend.Text = "Send Email";
            this.btnSend.Click += new EventHandler(this.btnSend_Click);

            // Add controls to form
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtBCC);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmbedImage);
            this.Controls.Add(this.richTextBody);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnAddAttachment);
            this.Controls.Add(this.btnSend);

            // Form configurations
            this.ClientSize = new Size(600, 550);
            this.Text = "Email Sender";
            this.ResumeLayout(false);
        }
    }
}
