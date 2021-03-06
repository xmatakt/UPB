﻿namespace cryptography
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chooseEnc_label = new System.Windows.Forms.Label();
            this.chooseEnc_btn = new System.Windows.Forms.Button();
            this.chooseDec_btn = new System.Windows.Forms.Button();
            this.chooseDec_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.encTime_label = new System.Windows.Forms.Label();
            this.decTime_label = new System.Windows.Forms.Label();
            this.des_rb = new System.Windows.Forms.RadioButton();
            this.rc2_rb = new System.Windows.Forms.RadioButton();
            this.AES_rb = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chooseEnc_label
            // 
            this.chooseEnc_label.AutoSize = true;
            this.chooseEnc_label.Location = new System.Drawing.Point(18, 64);
            this.chooseEnc_label.Name = "chooseEnc_label";
            this.chooseEnc_label.Size = new System.Drawing.Size(166, 20);
            this.chooseEnc_label.TabIndex = 0;
            this.chooseEnc_label.Text = "Choose file to encrypt:";
            // 
            // chooseEnc_btn
            // 
            this.chooseEnc_btn.Location = new System.Drawing.Point(206, 60);
            this.chooseEnc_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chooseEnc_btn.Name = "chooseEnc_btn";
            this.chooseEnc_btn.Size = new System.Drawing.Size(84, 35);
            this.chooseEnc_btn.TabIndex = 1;
            this.chooseEnc_btn.Text = "Browse...";
            this.chooseEnc_btn.UseVisualStyleBackColor = true;
            this.chooseEnc_btn.Click += new System.EventHandler(this.chooseEnc_btn_Click);
            // 
            // chooseDec_btn
            // 
            this.chooseDec_btn.Location = new System.Drawing.Point(206, 102);
            this.chooseDec_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chooseDec_btn.Name = "chooseDec_btn";
            this.chooseDec_btn.Size = new System.Drawing.Size(84, 35);
            this.chooseDec_btn.TabIndex = 3;
            this.chooseDec_btn.Text = "Browse...";
            this.chooseDec_btn.UseVisualStyleBackColor = true;
            this.chooseDec_btn.Click += new System.EventHandler(this.chooseDec_btn_Click_1);
            // 
            // chooseDec_label
            // 
            this.chooseDec_label.AutoSize = true;
            this.chooseDec_label.Location = new System.Drawing.Point(18, 106);
            this.chooseDec_label.Name = "chooseDec_label";
            this.chooseDec_label.Size = new System.Drawing.Size(166, 20);
            this.chooseDec_label.TabIndex = 2;
            this.chooseDec_label.Text = "Choose file to decrypt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encryption time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Decryption time:";
            // 
            // encTime_label
            // 
            this.encTime_label.AutoSize = true;
            this.encTime_label.Location = new System.Drawing.Point(450, 64);
            this.encTime_label.Name = "encTime_label";
            this.encTime_label.Size = new System.Drawing.Size(109, 20);
            this.encTime_label.TabIndex = 6;
            this.encTime_label.Text = "Not measured";
            // 
            // decTime_label
            // 
            this.decTime_label.AutoSize = true;
            this.decTime_label.Location = new System.Drawing.Point(450, 110);
            this.decTime_label.Name = "decTime_label";
            this.decTime_label.Size = new System.Drawing.Size(109, 20);
            this.decTime_label.TabIndex = 7;
            this.decTime_label.Text = "Not measured";
            // 
            // des_rb
            // 
            this.des_rb.AutoSize = true;
            this.des_rb.Location = new System.Drawing.Point(107, 15);
            this.des_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.des_rb.Name = "des_rb";
            this.des_rb.Size = new System.Drawing.Size(77, 24);
            this.des_rb.TabIndex = 9;
            this.des_rb.Text = "3DES";
            this.des_rb.UseVisualStyleBackColor = true;
            // 
            // rc2_rb
            // 
            this.rc2_rb.AutoSize = true;
            this.rc2_rb.Location = new System.Drawing.Point(206, 15);
            this.rc2_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rc2_rb.Name = "rc2_rb";
            this.rc2_rb.Size = new System.Drawing.Size(66, 24);
            this.rc2_rb.TabIndex = 10;
            this.rc2_rb.Text = "RC2";
            this.rc2_rb.UseVisualStyleBackColor = true;
            // 
            // AES_rb
            // 
            this.AES_rb.AutoSize = true;
            this.AES_rb.Checked = true;
            this.AES_rb.Location = new System.Drawing.Point(21, 15);
            this.AES_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AES_rb.Name = "AES_rb";
            this.AES_rb.Size = new System.Drawing.Size(67, 24);
            this.AES_rb.TabIndex = 8;
            this.AES_rb.TabStop = true;
            this.AES_rb.Text = "AES";
            this.AES_rb.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 163);
            this.Controls.Add(this.rc2_rb);
            this.Controls.Add(this.des_rb);
            this.Controls.Add(this.AES_rb);
            this.Controls.Add(this.decTime_label);
            this.Controls.Add(this.encTime_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseDec_btn);
            this.Controls.Add(this.chooseDec_label);
            this.Controls.Add(this.chooseEnc_btn);
            this.Controls.Add(this.chooseEnc_label);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label chooseEnc_label;
        private System.Windows.Forms.Button chooseEnc_btn;
        private System.Windows.Forms.Button chooseDec_btn;
        private System.Windows.Forms.Label chooseDec_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label encTime_label;
        private System.Windows.Forms.Label decTime_label;
        private System.Windows.Forms.RadioButton des_rb;
        private System.Windows.Forms.RadioButton rc2_rb;
        private System.Windows.Forms.RadioButton AES_rb;
    }
}

