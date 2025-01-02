using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ANM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RSACryptoServiceProvider rsa;

        //Tạo khóa RSA
        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            int keySize = int.Parse(comboBoxKeySize.SelectedItem.ToString());
            rsa = new RSACryptoServiceProvider(keySize);
            textBoxPublicKey.Text = rsa.ToXmlString(false);  // Công khai
            textBoxPrivateKey.Text = rsa.ToXmlString(true);  // Bí mật
        }

        //Tạo chữ ký
        private void btnCreateSignature_Click(object sender, EventArgs e)
        {
            try
            {
                string data = File.ReadAllText(textBoxDataFile.Text);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] signature = rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());
                textBoxSignature.Text = Convert.ToBase64String(signature);
                richTextBoxLog.AppendText("Chữ ký đã được tạo thành công.\n");
            }
            catch (Exception ex)
            {
                richTextBoxLog.AppendText("Lỗi khi tạo chữ ký: " + ex.Message + "\n");
            }
        }

        //Xác thực chữ ký
        private void btnVerifySignature_Click(object sender, EventArgs e)
        {
            try
            {
                string data = File.ReadAllText(textBoxDataFile.Text);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] signatureBytes = Convert.FromBase64String(textBoxSignature.Text);
                bool isValid = rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signatureBytes);
                textBoxSignatureResult.Text = isValid ? "Chữ ký hợp lệ" : "Chữ ký không hợp lệ";
                richTextBoxLog.AppendText(isValid ? "Xác thực thành công.\n" : "Xác thực thất bại.\n");
            }
            catch (Exception ex)
            {
                richTextBoxLog.AppendText("Lỗi khi xác thực chữ ký: " + ex.Message + "\n");
            }
        }

        //Chọn tệp và tải dữ liệu
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDataFile.Text = openFileDialog.FileName;
            }
        }

        //Lưu và tải khóa
        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textBoxPrivateKey.Text);
            }
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPrivateKey.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        //Lưu và xuất chữ ký
        private void btnExportSignature_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textBoxSignature.Text);
            }
        }

        //Ẩn/Hiển thị khóa bí mật
        private void btnTogglePrivateKey_Click(object sender, EventArgs e)
        {
            textBoxPrivateKey.UseSystemPasswordChar = !textBoxPrivateKey.UseSystemPasswordChar;
        }

        private void comboBoxKeySize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
