namespace cryptography.Forms
{
    partial class PasswordForm
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
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.password_checkBox = new System.Windows.Forms.CheckBox();
            this.password_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(12, 29);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(215, 22);
            this.password_textBox.TabIndex = 0;
            this.password_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.password_textBox.TextChanged += new System.EventHandler(this.password_textBox_TextChanged);
            this.password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_textBox_KeyDown);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(12, 9);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(110, 17);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "Enter password:";
            // 
            // password_checkBox
            // 
            this.password_checkBox.AutoSize = true;
            this.password_checkBox.Location = new System.Drawing.Point(233, 31);
            this.password_checkBox.Name = "password_checkBox";
            this.password_checkBox.Size = new System.Drawing.Size(128, 21);
            this.password_checkBox.TabIndex = 2;
            this.password_checkBox.Text = "Show password";
            this.password_checkBox.UseVisualStyleBackColor = true;
            // 
            // password_btn
            // 
            this.password_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.password_btn.Location = new System.Drawing.Point(152, 61);
            this.password_btn.Name = "password_btn";
            this.password_btn.Size = new System.Drawing.Size(75, 33);
            this.password_btn.TabIndex = 3;
            this.password_btn.Text = "OK";
            this.password_btn.UseVisualStyleBackColor = true;
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 106);
            this.Controls.Add(this.password_btn);
            this.Controls.Add(this.password_checkBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.password_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.CheckBox password_checkBox;
        private System.Windows.Forms.Button password_btn;
    }
}