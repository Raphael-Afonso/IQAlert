namespace IQAlert.Forms
{
    partial class FrmSignalList
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
            this.SignalListTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SignalListTextBox
            // 
            this.SignalListTextBox.Location = new System.Drawing.Point(12, 33);
            this.SignalListTextBox.Name = "SignalListTextBox";
            this.SignalListTextBox.Size = new System.Drawing.Size(350, 152);
            this.SignalListTextBox.TabIndex = 0;
            this.SignalListTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cole a lista de sinais";
            // 
            // BtnGravar
            // 
            this.BtnGravar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnGravar.Location = new System.Drawing.Point(0, 200);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(376, 23);
            this.BtnGravar.TabIndex = 2;
            this.BtnGravar.Text = "Gravar";
            this.BtnGravar.UseVisualStyleBackColor = true;
            this.BtnGravar.Click += new System.EventHandler(this.Gravar);
            // 
            // FrmSignalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 223);
            this.Controls.Add(this.BtnGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SignalListTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSignalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de sinais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox SignalListTextBox;
        private Label label1;
        private Button BtnGravar;
    }
}