//http://stackoverflow.com/questions/8185747/how-can-i-unmask-c-sharp-password-textbox-and-mask-it-back-to-password

using System;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace cryptography.Forms
{
    public partial class PasswordForm : Form
    {
        public string Password { get; set; }

        public PasswordForm(string pathToFile, bool encrypt)
        {
            //System.IO.FileInfo fileInfo = new System.IO.FileInfo(pathToFile);
            InitializeComponent();
            //if (encrypt)
            //    password_label.Text = "Enter password to encrypt " + fileInfo.Name + ":";
            //else
            //    password_label.Text = "Enter password to decrypt " + fileInfo.Name + ":";
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            Password = password_textBox.Text;
        }

        private void PasswordForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void password_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            password_textBox.PasswordChar = password_checkBox.Checked ? '\0' : '*';
        }
    }
}
