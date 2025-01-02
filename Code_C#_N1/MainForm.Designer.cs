namespace RSAEncryptionApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.tabEncryption = new System.Windows.Forms.TabPage();
            this.tabSignature = new System.Windows.Forms.TabPage();

            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.btnSaveKeys = new System.Windows.Forms.Button();
            this.btnLoadKeys = new System.Windows.Forms.Button();

            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnSaveEncrypted = new System.Windows.Forms.Button();
            this.btnLoadEncrypted = new System.Windows.Forms.Button();

            this.txtSignature = new System.Windows.Forms.TextBox();
            this.txtVerificationResult = new System.Windows.Forms.TextBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnSignFile = new System.Windows.Forms.Button(); // Ký tệp
            this.btnVerifyFile = new System.Windows.Forms.Button(); // Xác minh tệp

            // Tab Control
            this.tabControl.Controls.Add(this.tabKeys);
            this.tabControl.Controls.Add(this.tabEncryption);
            this.tabControl.Controls.Add(this.tabSignature);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Padding = new System.Drawing.Point(10, 10);

            // Keys Tab
            this.tabKeys.Controls.Add(this.txtPublicKey);
            this.tabKeys.Controls.Add(this.txtPrivateKey);
            this.tabKeys.Controls.Add(this.btnGenerateKeys);
            this.tabKeys.Controls.Add(this.btnSaveKeys);
            this.tabKeys.Controls.Add(this.btnLoadKeys);
            this.tabKeys.Text = "Quản lý khóa";

            // Encryption Tab
            this.tabEncryption.Controls.Add(this.txtOriginal);
            this.tabEncryption.Controls.Add(this.txtEncrypted);
            this.tabEncryption.Controls.Add(this.txtDecrypted);
            this.tabEncryption.Controls.Add(this.btnEncrypt);
            this.tabEncryption.Controls.Add(this.btnDecrypt);
            this.tabEncryption.Controls.Add(this.btnSaveEncrypted);
            this.tabEncryption.Controls.Add(this.btnLoadEncrypted);
            this.tabEncryption.Text = "Mã hóa/Giải mã";

            // Signature Tab
            this.tabSignature.Controls.Add(this.txtSignature);
            this.tabSignature.Controls.Add(this.txtVerificationResult);
            this.tabSignature.Controls.Add(this.btnSign);
            this.tabSignature.Controls.Add(this.btnVerify);
            this.tabSignature.Controls.Add(this.btnSignFile); // Thêm nút Ký tệp
            this.tabSignature.Controls.Add(this.btnVerifyFile); // Thêm nút Xác minh tệp
            this.tabSignature.Text = "Chữ ký số";

            // txtPublicKey
            this.txtPublicKey.Location = new System.Drawing.Point(20, 20);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Size = new System.Drawing.Size(600, 120);
            this.txtPublicKey.Font = new Font("Arial", 10);
            this.txtPublicKey.PlaceholderText = "Khóa công khai...";

            // txtPrivateKey
            this.txtPrivateKey.Location = new System.Drawing.Point(20, 160);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Size = new System.Drawing.Size(600, 120);
            this.txtPrivateKey.Font = new Font("Arial", 10);
            this.txtPrivateKey.PlaceholderText = "Khóa riêng tư...";

            // btnGenerateKeys
            this.btnGenerateKeys.Location = new System.Drawing.Point(640, 20);
            this.btnGenerateKeys.Size = new System.Drawing.Size(150, 40);
            this.btnGenerateKeys.BackColor = Color.LightSkyBlue;
            this.btnGenerateKeys.FlatStyle = FlatStyle.Flat;
            this.btnGenerateKeys.Text = "Tạo khóa";
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);

            // btnSaveKeys
            this.btnSaveKeys.Location = new System.Drawing.Point(640, 80);
            this.btnSaveKeys.Size = new System.Drawing.Size(150, 40);
            this.btnSaveKeys.BackColor = Color.LightSkyBlue;
            this.btnSaveKeys.FlatStyle = FlatStyle.Flat;
            this.btnSaveKeys.Text = "Lưu khóa";
            this.btnSaveKeys.Click += new System.EventHandler(this.btnSaveKeys_Click);

            // btnLoadKeys
            this.btnLoadKeys.Location = new System.Drawing.Point(640, 140);
            this.btnLoadKeys.Size = new System.Drawing.Size(150, 40);
            this.btnLoadKeys.BackColor = Color.LightSkyBlue;
            this.btnLoadKeys.FlatStyle = FlatStyle.Flat;
            this.btnLoadKeys.Text = "Tải khóa";
            this.btnLoadKeys.Click += new System.EventHandler(this.btnLoadKeys_Click);

            // txtOriginal
            this.txtOriginal.Location = new System.Drawing.Point(20, 20);
            this.txtOriginal.Multiline = true;
            this.txtOriginal.Size = new System.Drawing.Size(600, 50);
            this.txtOriginal.Font = new Font("Arial", 10);
            this.txtOriginal.PlaceholderText = "Văn bản gốc...";

            // txtEncrypted
            this.txtEncrypted.Location = new System.Drawing.Point(20, 90);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Size = new System.Drawing.Size(600, 50);
            this.txtEncrypted.Font = new Font("Arial", 10);
            this.txtEncrypted.PlaceholderText = "Văn bản đã mã hóa...";

            // txtDecrypted
            this.txtDecrypted.Location = new System.Drawing.Point(20, 160);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.Size = new System.Drawing.Size(600, 50);
            this.txtDecrypted.Font = new Font("Arial", 10);
            this.txtDecrypted.PlaceholderText = "Văn bản đã giải mã...";

            // btnEncrypt
            this.btnEncrypt.Location = new System.Drawing.Point(640, 20);
            this.btnEncrypt.Size = new System.Drawing.Size(150, 40);
            this.btnEncrypt.BackColor = Color.LightSkyBlue;
            this.btnEncrypt.FlatStyle = FlatStyle.Flat;
            this.btnEncrypt.Text = "Mã hóa";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);

            // btnDecrypt
            this.btnDecrypt.Location = new System.Drawing.Point(640, 80);
            this.btnDecrypt.Size = new System.Drawing.Size(150, 40);
            this.btnDecrypt.BackColor = Color.LightSkyBlue;
            this.btnDecrypt.FlatStyle = FlatStyle.Flat;
            this.btnDecrypt.Text = "Giải mã";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);

            // txtSignature
            this.txtSignature.Location = new System.Drawing.Point(20, 20);
            this.txtSignature.Multiline = true;
            this.txtSignature.Size = new System.Drawing.Size(600, 50);
            this.txtSignature.Font = new Font("Arial", 10);
            this.txtSignature.PlaceholderText = "Chữ ký...";

            // txtVerificationResult
            this.txtVerificationResult.Location = new System.Drawing.Point(20, 90);
            this.txtVerificationResult.Size = new System.Drawing.Size(600, 25);
            this.txtVerificationResult.Font = new Font("Arial", 10);
            this.txtVerificationResult.ReadOnly = true;
            this.txtVerificationResult.PlaceholderText = "Kết quả xác thực...";

            // btnSign
            this.btnSign.Location = new System.Drawing.Point(640, 20);
            this.btnSign.Size = new System.Drawing.Size(150, 40);
            this.btnSign.BackColor = Color.LightSkyBlue;
            this.btnSign.FlatStyle = FlatStyle.Flat;
            this.btnSign.Text = "Ký";
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);

            // btnVerify
            this.btnVerify.Location = new System.Drawing.Point(640, 80);
            this.btnVerify.Size = new System.Drawing.Size(150, 40);
            this.btnVerify.BackColor = Color.LightSkyBlue;
            this.btnVerify.FlatStyle = FlatStyle.Flat;
            this.btnVerify.Text = "Xác thực";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // btnSignFile
            this.btnSignFile.Location = new System.Drawing.Point(640, 140);
            this.btnSignFile.Size = new System.Drawing.Size(150, 40);
            this.btnSignFile.BackColor = Color.LightGreen;
            this.btnSignFile.FlatStyle = FlatStyle.Flat;
            this.btnSignFile.Text = "Ký tệp";
            this.btnSignFile.Click += new System.EventHandler(this.btnSignFile_Click);

            // btnVerifyFile
            this.btnVerifyFile.Location = new System.Drawing.Point(640, 200);
            this.btnVerifyFile.Size = new System.Drawing.Size(150, 40);
            this.btnVerifyFile.BackColor = Color.LightGreen;
            this.btnVerifyFile.FlatStyle = FlatStyle.Flat;
            this.btnVerifyFile.Text = "Xác minh tệp";
            this.btnVerifyFile.Click += new System.EventHandler(this.btnVerifyFile_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Text = "Công cụ RSA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.TabPage tabEncryption;
        private System.Windows.Forms.TabPage tabSignature;

        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Button btnSaveKeys;
        private System.Windows.Forms.Button btnLoadKeys;

        private System.Windows.Forms.TextBox txtOriginal;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnSaveEncrypted;
        private System.Windows.Forms.Button btnLoadEncrypted;

        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.TextBox txtVerificationResult;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnSignFile;
        private System.Windows.Forms.Button btnVerifyFile;
    }
}
