namespace View
{
    partial class SaveDialog
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
            saveName = new TextBox();
            label1 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // saveName
            // 
            saveName.Location = new Point(12, 36);
            saveName.Name = "saveName";
            saveName.Size = new Size(238, 27);
            saveName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "Save Name:";
            // 
            // okButton
            // 
            okButton.Location = new Point(18, 80);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 2;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += Save;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(156, 80);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel;
            // 
            // SaveDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 123);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            Controls.Add(saveName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaveDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save - Nine Men's Morris";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox saveName;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
    }
}