namespace View
{
    partial class AboutForm
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
            components = new System.ComponentModel.Container();
            logo = new Tile();
            aboutLabel = new Label();
            logoTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            logo.BackColor = Color.Transparent;
            logo.Image = WinformsView.Properties.Resources.empty;
            logo.Index = 5;
            logo.Location = new Point(12, 47);
            logo.Name = "logo";
            logo.Size = new Size(132, 126);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 21;
            logo.TabStop = false;
            // 
            // aboutLabel
            // 
            aboutLabel.AutoSize = true;
            aboutLabel.Location = new Point(166, 81);
            aboutLabel.Name = "aboutLabel";
            aboutLabel.Size = new Size(261, 60);
            aboutLabel.TabIndex = 22;
            aboutLabel.Text = "Nine Men's Morris\r\n\r\nCreated by: hypergonial\r\n";
            // 
            // logoTimer
            // 
            logoTimer.Interval = 1000;
            logoTimer.Tick += UpdateLogo;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 234);
            Controls.Add(aboutLabel);
            Controls.Add(logo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About - Mill";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Tile logo;
        private Label aboutLabel;
        private System.Windows.Forms.Timer logoTimer;
    }
}
