namespace ANM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxKeySize;
        private System.Windows.Forms.TextBox textBoxPublicKey;
        private System.Windows.Forms.TextBox textBoxPrivateKey;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Button btnLoadKey;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTogglePrivateKey;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnCreateSignature;
        private System.Windows.Forms.Button btnVerifySignature;
        private System.Windows.Forms.Button btnExportSignature;
        private System.Windows.Forms.Label lblKeySize;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblDataFile;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblSignatureResult;
        private System.Windows.Forms.TextBox textBoxDataFile;
        private System.Windows.Forms.TextBox textBoxSignature;
        private System.Windows.Forms.TextBox textBoxSignatureResult;

        // Giải phóng tài nguyên khi form đóng
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Thiết lập các điều khiển và giao diện form
        private void InitializeComponent()
        {
            this.comboBoxKeySize = new System.Windows.Forms.ComboBox();
            this.textBoxPublicKey = new System.Windows.Forms.TextBox();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnLoadKey = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTogglePrivateKey = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnCreateSignature = new System.Windows.Forms.Button();
            this.btnVerifySignature = new System.Windows.Forms.Button();
            this.btnExportSignature = new System.Windows.Forms.Button();
            this.lblKeySize = new System.Windows.Forms.Label();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblDataFile = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblSignatureResult = new System.Windows.Forms.Label();
            this.textBoxDataFile = new System.Windows.Forms.TextBox();
            this.textBoxSignature = new System.Windows.Forms.TextBox();
            this.textBoxSignatureResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxKeySize
            // 
            this.comboBoxKeySize.FormattingEnabled = true;
            this.comboBoxKeySize.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096"});
            this.comboBoxKeySize.Location = new System.Drawing.Point(115, 147);
            this.comboBoxKeySize.Name = "comboBoxKeySize";
            this.comboBoxKeySize.Size = new System.Drawing.Size(121, 24);
            this.comboBoxKeySize.TabIndex = 6;
            this.comboBoxKeySize.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeySize_SelectedIndexChanged);
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.Location = new System.Drawing.Point(115, 77);
            this.textBoxPublicKey.Multiline = true;
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.Size = new System.Drawing.Size(400, 60);
            this.textBoxPublicKey.TabIndex = 4;
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Location = new System.Drawing.Point(115, 12);
            this.textBoxPrivateKey.Multiline = true;
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(400, 60);
            this.textBoxPrivateKey.TabIndex = 1;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Location = new System.Drawing.Point(521, 145);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(100, 30);
            this.btnGenerateKeys.TabIndex = 7;
            this.btnGenerateKeys.Text = "Tạo khóa";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(0, 0);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 0;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(0, 0);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 0;
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.Location = new System.Drawing.Point(0, 0);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(75, 23);
            this.btnSaveKey.TabIndex = 0;
            // 
            // btnLoadKey
            // 
            this.btnLoadKey.Location = new System.Drawing.Point(0, 0);
            this.btnLoadKey.Name = "btnLoadKey";
            this.btnLoadKey.Size = new System.Drawing.Size(75, 23);
            this.btnLoadKey.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            // 
            // btnTogglePrivateKey
            // 
            this.btnTogglePrivateKey.Location = new System.Drawing.Point(521, 12);
            this.btnTogglePrivateKey.Name = "btnTogglePrivateKey";
            this.btnTogglePrivateKey.Size = new System.Drawing.Size(100, 30);
            this.btnTogglePrivateKey.TabIndex = 2;
            this.btnTogglePrivateKey.Text = "Hiển/ẩn khóa bí mật";
            this.btnTogglePrivateKey.UseVisualStyleBackColor = true;
            this.btnTogglePrivateKey.Click += new System.EventHandler(this.btnTogglePrivateKey_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(521, 185);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(100, 30);
            this.btnChooseFile.TabIndex = 10;
            this.btnChooseFile.Text = "Chọn tệp";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnCreateSignature
            // 
            this.btnCreateSignature.Location = new System.Drawing.Point(521, 215);
            this.btnCreateSignature.Name = "btnCreateSignature";
            this.btnCreateSignature.Size = new System.Drawing.Size(100, 30);
            this.btnCreateSignature.TabIndex = 13;
            this.btnCreateSignature.Text = "Tạo chữ ký";
            this.btnCreateSignature.UseVisualStyleBackColor = true;
            this.btnCreateSignature.Click += new System.EventHandler(this.btnCreateSignature_Click);
            // 
            // btnVerifySignature
            // 
            this.btnVerifySignature.Location = new System.Drawing.Point(521, 275);
            this.btnVerifySignature.Name = "btnVerifySignature";
            this.btnVerifySignature.Size = new System.Drawing.Size(128, 30);
            this.btnVerifySignature.TabIndex = 17;
            this.btnVerifySignature.Text = "Xác thực chữ ký";
            this.btnVerifySignature.UseVisualStyleBackColor = true;
            this.btnVerifySignature.Click += new System.EventHandler(this.btnVerifySignature_Click);
            // 
            // btnExportSignature
            // 
            this.btnExportSignature.Location = new System.Drawing.Point(521, 311);
            this.btnExportSignature.Name = "btnExportSignature";
            this.btnExportSignature.Size = new System.Drawing.Size(100, 30);
            this.btnExportSignature.TabIndex = 18;
            this.btnExportSignature.Text = "Xuất chữ ký";
            this.btnExportSignature.UseVisualStyleBackColor = true;
            this.btnExportSignature.Click += new System.EventHandler(this.btnExportSignature_Click);
            // 
            // lblKeySize
            // 
            this.lblKeySize.AutoSize = true;
            this.lblKeySize.Location = new System.Drawing.Point(12, 150);
            this.lblKeySize.Name = "lblKeySize";
            this.lblKeySize.Size = new System.Drawing.Size(103, 16);
            this.lblKeySize.TabIndex = 5;
            this.lblKeySize.Text = "Kích thước khóa:";
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(12, 80);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(102, 16);
            this.lblPublicKey.TabIndex = 3;
            this.lblPublicKey.Text = "Khóa công khai:";
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(12, 15);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(80, 16);
            this.lblPrivateKey.TabIndex = 0;
            this.lblPrivateKey.Text = "Khóa bí mật:";
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(0, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(100, 23);
            this.lblLog.TabIndex = 0;
            // 
            // lblDataFile
            // 
            this.lblDataFile.AutoSize = true;
            this.lblDataFile.Location = new System.Drawing.Point(12, 190);
            this.lblDataFile.Name = "lblDataFile";
            this.lblDataFile.Size = new System.Drawing.Size(51, 16);
            this.lblDataFile.TabIndex = 8;
            this.lblDataFile.Text = "Dữ liệu:";
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(12, 220);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(50, 16);
            this.lblSignature.TabIndex = 11;
            this.lblSignature.Text = "Chữ ký:";
            // 
            // lblSignatureResult
            // 
            this.lblSignatureResult.AutoSize = true;
            this.lblSignatureResult.Location = new System.Drawing.Point(12, 280);
            this.lblSignatureResult.Name = "lblSignatureResult";
            this.lblSignatureResult.Size = new System.Drawing.Size(55, 16);
            this.lblSignatureResult.TabIndex = 15;
            this.lblSignatureResult.Text = "Kết quả:";
            // 
            // textBoxDataFile
            // 
            this.textBoxDataFile.Location = new System.Drawing.Point(115, 187);
            this.textBoxDataFile.Name = "textBoxDataFile";
            this.textBoxDataFile.Size = new System.Drawing.Size(400, 22);
            this.textBoxDataFile.TabIndex = 9;
            // 
            // textBoxSignature
            // 
            this.textBoxSignature.Location = new System.Drawing.Point(115, 217);
            this.textBoxSignature.Name = "textBoxSignature";
            this.textBoxSignature.Size = new System.Drawing.Size(400, 22);
            this.textBoxSignature.TabIndex = 12;
            // 
            // textBoxSignatureResult
            // 
            this.textBoxSignatureResult.Location = new System.Drawing.Point(115, 277);
            this.textBoxSignatureResult.Name = "textBoxSignatureResult";
            this.textBoxSignatureResult.Size = new System.Drawing.Size(400, 22);
            this.textBoxSignatureResult.TabIndex = 16;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1365, 651);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.textBoxPrivateKey);
            this.Controls.Add(this.btnTogglePrivateKey);
            this.Controls.Add(this.lblPublicKey);
            this.Controls.Add(this.textBoxPublicKey);
            this.Controls.Add(this.lblKeySize);
            this.Controls.Add(this.comboBoxKeySize);
            this.Controls.Add(this.btnGenerateKeys);
            this.Controls.Add(this.lblDataFile);
            this.Controls.Add(this.textBoxDataFile);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblSignature);
            this.Controls.Add(this.textBoxSignature);
            this.Controls.Add(this.btnCreateSignature);
            this.Controls.Add(this.lblSignatureResult);
            this.Controls.Add(this.textBoxSignatureResult);
            this.Controls.Add(this.btnVerifySignature);
            this.Controls.Add(this.btnExportSignature);
            this.Name = "Form1";
            this.Text = "RSA Digital Signature Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}