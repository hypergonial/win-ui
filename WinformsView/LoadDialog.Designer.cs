namespace View
{
    partial class LoadDialog
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
            loadLayout = new FlowLayoutPanel();
            loadLabel = new Label();
            SuspendLayout();
            // 
            // loadLayout
            // 
            loadLayout.AutoScroll = true;
            loadLayout.FlowDirection = FlowDirection.TopDown;
            loadLayout.Location = new Point(12, 63);
            loadLayout.Name = "loadLayout";
            loadLayout.Size = new Size(209, 367);
            loadLayout.TabIndex = 0;
            loadLayout.WrapContents = false;
            // 
            // loadLabel
            // 
            loadLabel.AutoSize = true;
            loadLabel.Location = new Point(12, 25);
            loadLabel.Name = "loadLabel";
            loadLabel.Size = new Size(149, 20);
            loadLabel.TabIndex = 1;
            loadLabel.Text = "Select a save to load:";
            // 
            // LoadDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 442);
            Controls.Add(loadLabel);
            Controls.Add(loadLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoadDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Load - Nine Men's Morris";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel loadLayout;
        private Label loadLabel;
    }
}