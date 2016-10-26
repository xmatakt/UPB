using System;
using System.Text;
using System.Windows.Forms;

using cryptography.CryptgraphyAlgorythms;
using cryptography.Forms;

namespace cryptography
{
    public partial class Form1 : Form
    {
        private string sourceFile = "";
        private string encryptedFile = "";
        private PasswordForm passwordForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseEnc_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourceFile = openFileDialog1.FileName;
                try
                {
                    passwordForm = new PasswordForm(sourceFile, true);
                    if (passwordForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if(AES_rb.Checked)
                        {
                            AesAlgorithmClass ac = new AesAlgorithmClass(passwordForm.Password);
                            encTime_label.Text = ac.EncryptFile(sourceFile);
                        }
                        if (des_rb.Checked)
                        {
                            TripleDesAlgorithmClass ac = new TripleDesAlgorithmClass(passwordForm.Password);
                            encTime_label.Text = ac.EncryptFile(sourceFile);
                        }
                        if (rc2_rb.Checked)
                        {
                            RC2AlgorithmClass ac = new RC2AlgorithmClass(passwordForm.Password);
                            encTime_label.Text = ac.EncryptFile(sourceFile);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to encrypt data!\n" + ex.Message, "Vnimanie!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //AesCrypt ac = new AesCrypt("hesloNaPevno212");
                //ac.EncryptFile(path);
            }
        }

        private void chooseDec_btn_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Encrypted files (*.enc)|*.enc";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string encryptedFile = openFileDialog1.FileName;
                try
                {
                    passwordForm = new PasswordForm(encryptedFile, false);
                    if (passwordForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (AES_rb.Checked)
                        {
                            AesAlgorithmClass ac = new AesAlgorithmClass(passwordForm.Password);
                            decTime_label.Text = ac.DecryptFile(encryptedFile);
                        }
                        if (des_rb.Checked)
                        {
                            TripleDesAlgorithmClass ac = new TripleDesAlgorithmClass(passwordForm.Password);
                            decTime_label.Text = ac.DecryptFile(encryptedFile);
                        }
                        if (rc2_rb.Checked)
                        {
                            RC2AlgorithmClass ac = new RC2AlgorithmClass(passwordForm.Password);
                            decTime_label.Text = ac.DecryptFile(encryptedFile);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to encrypt data!\n" + ex.Message, "Vnimanie!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //AesCrypt ac = new AesCrypt("hesloNaPevno212");
                //ac.DecryptFile(path);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
