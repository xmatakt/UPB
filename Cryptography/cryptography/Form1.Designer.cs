namespace cryptography
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
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chooseEnc_label
            // 
            this.chooseEnc_label.AutoSize = true;
            this.chooseEnc_label.Location = new System.Drawing.Point(12, 15);
            this.chooseEnc_label.Name = "chooseEnc_label";
            this.chooseEnc_label.Size = new System.Drawing.Size(149, 17);
            this.chooseEnc_label.TabIndex = 0;
            this.chooseEnc_label.Text = "Choose file to encrypt:";
            // 
            // chooseEnc_btn
            // 
            this.chooseEnc_btn.Location = new System.Drawing.Point(179, 12);
            this.chooseEnc_btn.Name = "chooseEnc_btn";
            this.chooseEnc_btn.Size = new System.Drawing.Size(75, 28);
            this.chooseEnc_btn.TabIndex = 1;
            this.chooseEnc_btn.Text = "Browse...";
            this.chooseEnc_btn.UseVisualStyleBackColor = true;
            this.chooseEnc_btn.Click += new System.EventHandler(this.chooseEnc_btn_Click);
            // 
            // chooseDec_btn
            // 
            this.chooseDec_btn.Location = new System.Drawing.Point(179, 46);
            this.chooseDec_btn.Name = "chooseDec_btn";
            this.chooseDec_btn.Size = new System.Drawing.Size(75, 28);
            this.chooseDec_btn.TabIndex = 3;
            this.chooseDec_btn.Text = "Browse...";
            this.chooseDec_btn.UseVisualStyleBackColor = true;
            this.chooseDec_btn.Click += new System.EventHandler(this.chooseDec_btn_Click_1);
            // 
            // chooseDec_label
            // 
            this.chooseDec_label.AutoSize = true;
            this.chooseDec_label.Location = new System.Drawing.Point(12, 49);
            this.chooseDec_label.Name = "chooseDec_label";
            this.chooseDec_label.Size = new System.Drawing.Size(149, 17);
            this.chooseDec_label.TabIndex = 2;
            this.chooseDec_label.Text = "Choose file to decrypt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encryption time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Decryption time:";
            // 
            // encTime_label
            // 
            this.encTime_label.AutoSize = true;
            this.encTime_label.Location = new System.Drawing.Point(396, 15);
            this.encTime_label.Name = "encTime_label";
            this.encTime_label.Size = new System.Drawing.Size(97, 17);
            this.encTime_label.TabIndex = 6;
            this.encTime_label.Text = "Not measured";
            // 
            // decTime_label
            // 
            this.decTime_label.AutoSize = true;
            this.decTime_label.Location = new System.Drawing.Point(396, 52);
            this.decTime_label.Name = "decTime_label";
            this.decTime_label.Size = new System.Drawing.Size(97, 17);
            this.decTime_label.TabIndex = 7;
            this.decTime_label.Text = "Not measured";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 87);
            this.Controls.Add(this.decTime_label);
            this.Controls.Add(this.encTime_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseDec_btn);
            this.Controls.Add(this.chooseDec_label);
            this.Controls.Add(this.chooseEnc_btn);
            this.Controls.Add(this.chooseEnc_label);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

