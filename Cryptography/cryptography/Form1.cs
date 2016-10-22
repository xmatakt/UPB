﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cryptography.CryptgraphyAlgorythms;

namespace cryptography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseEnc_btn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                string path = openFileDialog1.FileName;
                AesCrypt ac = new AesCrypt("hesloNaPevno212");
                ac.EncryptFile(path);
            }
        }

        private void chooseDec_btn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                string path = openFileDialog1.FileName;
                AesCrypt ac = new AesCrypt("hesloNaPevno212");
                ac.DecryptFile(path);
            }
        }
    }
}
