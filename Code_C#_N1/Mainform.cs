using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSAEncryptionApp
{
    public partial class MainForm : Form
    {
        private RSACryptoServiceProvider rsa;

        public MainForm()
        {
            InitializeComponent();
            rsa = new RSACryptoServiceProvider();
        }

        // Sinh khóa RSA mới
        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            rsa = new RSACryptoServiceProvider(2048); // Sinh khóa mới (2048-bit)
            txtPublicKey.Text = rsa.ToXmlString(false); // Khóa công khai
            txtPrivateKey.Text = rsa.ToXmlString(true); // Khóa riêng tư
        }

        // Lưu khóa vào tệp
        private void btnSaveKeys_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "XML Files|*.xml" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, txtPrivateKey.Text);
                MessageBox.Show("Khóa đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Tải khóa từ tệp
        private void btnLoadKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "XML Files|*.xml" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPrivateKey.Text = File.ReadAllText(openFileDialog.FileName);
                MessageBox.Show("Khóa đã được tải thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Mã hóa dữ liệu
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtOriginal?.Text ?? string.Empty;
            if (string.IsNullOrEmpty(txtPublicKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa công khai trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rsa.FromXmlString(txtPublicKey.Text); // Tải khóa công khai
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] encryptedBytes = rsa.Encrypt(inputBytes, false); // Mã hóa
            txtEncrypted.Text = Convert.ToBase64String(encryptedBytes); // Chuyển sang Base64 để hiển thị
        }

        // Giải mã dữ liệu
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string encryptedText = txtEncrypted?.Text ?? string.Empty;
            if (string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa riêng tư trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rsa.FromXmlString(txtPrivateKey.Text); // Tải khóa riêng tư
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false); // Giải mã
                txtDecrypted.Text = Encoding.UTF8.GetString(decryptedBytes); // Hiển thị dữ liệu gốc
            }
            catch
            {
                txtDecrypted.Text = "Giải mã không thành công!";
            }
        }

        // Ký văn bản
        private void btnSign_Click(object sender, EventArgs e)
        {
            string input = txtOriginal?.Text ?? string.Empty;
            if (string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa riêng tư trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rsa.FromXmlString(txtPrivateKey.Text); 
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] signedData = rsa.SignData(inputBytes, CryptoConfig.MapNameToOID("SHA256")); 
            txtSignature.Text = Convert.ToBase64String(signedData); 
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            string input = txtOriginal?.Text ?? string.Empty;
            string signature = txtSignature?.Text ?? string.Empty;

            if (string.IsNullOrEmpty(txtPublicKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa công khai trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rsa.FromXmlString(txtPublicKey.Text); 
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] signatureBytes = Convert.FromBase64String(signature);

            bool isValid = rsa.VerifyData(inputBytes, CryptoConfig.MapNameToOID("SHA256"), signatureBytes); 
            txtVerificationResult.Text = isValid ? "Chữ ký hợp lệ!" : "Chữ ký không hợp lệ!";
        }


        private void btnSignFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa riêng tư trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "All Files|*.*" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    byte[] fileContent = File.ReadAllBytes(filePath);

                    rsa.FromXmlString(txtPrivateKey.Text);
                    byte[] signedData = rsa.SignData(fileContent, CryptoConfig.MapNameToOID("SHA256"));

                    txtSignature.Text = Convert.ToBase64String(signedData);

                    SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Signature Files|*.sig" };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, txtSignature.Text);
                        MessageBox.Show("Chữ ký đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ký tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnVerifyFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPublicKey.Text))
            {
                MessageBox.Show("Vui lòng sinh hoặc nhập khóa công khai trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "All Files|*.*" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileContent = File.ReadAllBytes(filePath);

                OpenFileDialog sigDialog = new OpenFileDialog { Filter = "Signature Files|*.sig" };
                if (sigDialog.ShowDialog() == DialogResult.OK)
                {
                    string signaturePath = sigDialog.FileName;
                    byte[] signatureBytes = Convert.FromBase64String(File.ReadAllText(signaturePath));

                    rsa.FromXmlString(txtPublicKey.Text);
                    bool isValid = rsa.VerifyData(fileContent, CryptoConfig.MapNameToOID("SHA256"), signatureBytes);

                    txtVerificationResult.Text = isValid ? "Chữ ký tệp hợp lệ!" : "Chữ ký tệp không hợp lệ!";
                    MessageBox.Show(txtVerificationResult.Text, "Kết quả xác minh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
