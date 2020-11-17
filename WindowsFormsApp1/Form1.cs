using System;
using System.Windows.Forms;
using Chilkat;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || 
                string.IsNullOrWhiteSpace(textBox2.Text))
                MessageBox.Show("Please, enter text to all required text fields");

            Crypt2 cryptDecrypt = new Crypt2();
            cryptDecrypt.CryptAlgorithm = "aes";
            cryptDecrypt.KeyLength = 128;
            cryptDecrypt.CipherMode = "ctr";
            cryptDecrypt.EncodingMode = "base64";

            string hexKey = textBox1.Text;
            cryptDecrypt.SetEncodedKey(hexKey, "ascii");
            string hexIv = textBox2.Text;
            cryptDecrypt.SetEncodedIV(hexIv, "ascii");

            if (checkBox1.Checked)
            {
                richTextBox2.Text = cryptDecrypt.DecryptStringENC(richTextBox1.Text);
            }
            else
            {
                richTextBox2.Text = cryptDecrypt.EncryptStringENC(richTextBox1.Text);
            }
        }
    }
}
