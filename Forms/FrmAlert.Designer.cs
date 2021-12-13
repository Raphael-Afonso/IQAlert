namespace IQAlert.Forms
{
    partial class FrmAlert
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
            this.components = new System.ComponentModel.Container();
            this.PicSignalNow = new System.Windows.Forms.PictureBox();
            this.LbSignalNow = new System.Windows.Forms.Label();
            this.LbTimeNow = new System.Windows.Forms.Label();
            this.LbTimeAfter = new System.Windows.Forms.Label();
            this.LbSignalAfter = new System.Windows.Forms.Label();
            this.PicSignalAfter = new System.Windows.Forms.PictureBox();
            this.SignalTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnConfig = new System.Windows.Forms.Button();
            this.Separator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicSignalNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSignalAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // PicSignalNow
            // 
            this.PicSignalNow.Location = new System.Drawing.Point(164, 34);
            this.PicSignalNow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicSignalNow.Name = "PicSignalNow";
            this.PicSignalNow.Size = new System.Drawing.Size(34, 34);
            this.PicSignalNow.TabIndex = 0;
            this.PicSignalNow.TabStop = false;
            // 
            // LbSignalNow
            // 
            this.LbSignalNow.AutoSize = true;
            this.LbSignalNow.Location = new System.Drawing.Point(24, 34);
            this.LbSignalNow.Name = "LbSignalNow";
            this.LbSignalNow.Size = new System.Drawing.Size(51, 20);
            this.LbSignalNow.TabIndex = 1;
            this.LbSignalNow.Text = "Ativo: ";
            // 
            // LbTimeNow
            // 
            this.LbTimeNow.AutoSize = true;
            this.LbTimeNow.Location = new System.Drawing.Point(24, 64);
            this.LbTimeNow.Name = "LbTimeNow";
            this.LbTimeNow.Size = new System.Drawing.Size(53, 20);
            this.LbTimeNow.TabIndex = 2;
            this.LbTimeNow.Text = "Hora:  ";
            // 
            // LbTimeAfter
            // 
            this.LbTimeAfter.AutoSize = true;
            this.LbTimeAfter.Location = new System.Drawing.Point(24, 157);
            this.LbTimeAfter.Name = "LbTimeAfter";
            this.LbTimeAfter.Size = new System.Drawing.Size(53, 20);
            this.LbTimeAfter.TabIndex = 5;
            this.LbTimeAfter.Text = "Hora:  ";
            // 
            // LbSignalAfter
            // 
            this.LbSignalAfter.AutoSize = true;
            this.LbSignalAfter.Location = new System.Drawing.Point(24, 127);
            this.LbSignalAfter.Name = "LbSignalAfter";
            this.LbSignalAfter.Size = new System.Drawing.Size(51, 20);
            this.LbSignalAfter.TabIndex = 4;
            this.LbSignalAfter.Text = "Ativo: ";
            // 
            // PicSignalAfter
            // 
            this.PicSignalAfter.Location = new System.Drawing.Point(164, 127);
            this.PicSignalAfter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicSignalAfter.Name = "PicSignalAfter";
            this.PicSignalAfter.Size = new System.Drawing.Size(34, 34);
            this.PicSignalAfter.TabIndex = 6;
            this.PicSignalAfter.TabStop = false;
            // 
            // SignalTimer
            // 
            this.SignalTimer.Enabled = true;
            this.SignalTimer.Interval = 300;
            this.SignalTimer.Tick += new System.EventHandler(this.SignalTimer_Tick);
            // 
            // BtnConfig
            // 
            this.BtnConfig.Image = global::IQAlert.Properties.Resources.Engrenagem;
            this.BtnConfig.Location = new System.Drawing.Point(3, 3);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(29, 28);
            this.BtnConfig.TabIndex = 7;
            this.BtnConfig.UseVisualStyleBackColor = true;
            this.BtnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.Color.Black;
            this.Separator.Location = new System.Drawing.Point(69, 110);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(150, 1);
            this.Separator.TabIndex = 8;
            this.Separator.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Próximo";
            // 
            // FrmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(224, 210);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.BtnConfig);
            this.Controls.Add(this.PicSignalAfter);
            this.Controls.Add(this.LbTimeAfter);
            this.Controls.Add(this.LbSignalAfter);
            this.Controls.Add(this.LbTimeNow);
            this.Controls.Add(this.LbSignalNow);
            this.Controls.Add(this.PicSignalNow);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAlert";
            this.Opacity = 0.7D;
            this.Text = "FrmAlert";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicSignalNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSignalAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox PicSignalNow;
        private Label LbSignalNow;
        private Label LbTimeNow;
        private Label LbTimeAfter;
        private Label LbSignalAfter;
        private PictureBox PicSignalAfter;
        private System.Windows.Forms.Timer SignalTimer;
        private Button BtnConfig;
        private Label Separator;
        private Label label1;
    }
}