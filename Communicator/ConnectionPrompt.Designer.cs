namespace Communicator
{
    partial class ConnectionPrompt
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
            this.label1 = new System.Windows.Forms.Label();
            this.user_nickname_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Yes_button = new System.Windows.Forms.Button();
            this.No_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Przychodzące połączenie od:";
            // 
            // user_nickname_label
            // 
            this.user_nickname_label.AutoSize = true;
            this.user_nickname_label.Location = new System.Drawing.Point(158, 13);
            this.user_nickname_label.Name = "user_nickname_label";
            this.user_nickname_label.Size = new System.Drawing.Size(27, 13);
            this.user_nickname_label.TabIndex = 1;
            this.user_nickname_label.Text = "user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Czy chcesz nawiązać połączenie z tym użytkownikiem?";
            // 
            // Yes_button
            // 
            this.Yes_button.Location = new System.Drawing.Point(127, 51);
            this.Yes_button.Name = "Yes_button";
            this.Yes_button.Size = new System.Drawing.Size(75, 23);
            this.Yes_button.TabIndex = 3;
            this.Yes_button.Text = "Tak";
            this.Yes_button.UseVisualStyleBackColor = true;
            this.Yes_button.Click += new System.EventHandler(this.Yes_button_Click);
            // 
            // No_button
            // 
            this.No_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.No_button.Location = new System.Drawing.Point(208, 51);
            this.No_button.Name = "No_button";
            this.No_button.Size = new System.Drawing.Size(75, 23);
            this.No_button.TabIndex = 4;
            this.No_button.Text = "Nie";
            this.No_button.UseVisualStyleBackColor = true;
            this.No_button.Click += new System.EventHandler(this.No_button_Click);
            // 
            // ConnectionPrompt
            // 
            this.AcceptButton = this.Yes_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.No_button;
            this.ClientSize = new System.Drawing.Size(302, 86);
            this.Controls.Add(this.No_button);
            this.Controls.Add(this.Yes_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user_nickname_label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectionPrompt";
            this.Text = "Przychodzące połączenie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label user_nickname_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Yes_button;
        private System.Windows.Forms.Button No_button;
    }
}