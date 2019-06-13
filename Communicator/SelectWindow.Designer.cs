namespace Communicator
{
    partial class SelectWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Label_Username = new System.Windows.Forms.Label();
            this.listView_guests = new System.Windows.Forms.ListView();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.connectedWith_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twoja nazwa:";
            // 
            // Label_Username
            // 
            this.Label_Username.AutoSize = true;
            this.Label_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_Username.Location = new System.Drawing.Point(81, 9);
            this.Label_Username.Name = "Label_Username";
            this.Label_Username.Size = new System.Drawing.Size(0, 13);
            this.Label_Username.TabIndex = 2;
            // 
            // listView_guests
            // 
            this.listView_guests.GridLines = true;
            this.listView_guests.Location = new System.Drawing.Point(15, 25);
            this.listView_guests.MultiSelect = false;
            this.listView_guests.Name = "listView_guests";
            this.listView_guests.Size = new System.Drawing.Size(251, 270);
            this.listView_guests.TabIndex = 3;
            this.listView_guests.UseCompatibleStateImageBehavior = false;
            this.listView_guests.DoubleClick += new System.EventHandler(this.listView_guests_DoubleClick);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Enabled = false;
            this.disconnect_button.Location = new System.Drawing.Point(191, 301);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(75, 23);
            this.disconnect_button.TabIndex = 4;
            this.disconnect_button.Text = "Rozłącz";
            this.disconnect_button.UseVisualStyleBackColor = true;
            // 
            // connectedWith_label
            // 
            this.connectedWith_label.AutoSize = true;
            this.connectedWith_label.Location = new System.Drawing.Point(12, 306);
            this.connectedWith_label.Name = "connectedWith_label";
            this.connectedWith_label.Size = new System.Drawing.Size(77, 13);
            this.connectedWith_label.TabIndex = 5;
            this.connectedWith_label.Text = "Nie połączono";
            // 
            // SelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 329);
            this.Controls.Add(this.connectedWith_label);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.listView_guests);
            this.Controls.Add(this.Label_Username);
            this.Controls.Add(this.label1);
            this.Name = "SelectWindow";
            this.Text = "Lista użytkowników";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label_Username;
        private System.Windows.Forms.ListView listView_guests;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Label connectedWith_label;
    }
}

