using Model;

namespace View
{
    public sealed partial class BoardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boardGroup = new GroupBox();
            tile26 = new Tile();
            tile27 = new Tile();
            tile20 = new Tile();
            tile24 = new Tile();
            tile23 = new Tile();
            tile22 = new Tile();
            tile21 = new Tile();
            tile25 = new Tile();
            tile14 = new Tile();
            tile16 = new Tile();
            tile15 = new Tile();
            tile07 = new Tile();
            tile17 = new Tile();
            tile10 = new Tile();
            tile11 = new Tile();
            tile12 = new Tile();
            tile13 = new Tile();
            tile06 = new Tile();
            tile05 = new Tile();
            tile04 = new Tile();
            tile03 = new Tile();
            tile02 = new Tile();
            tile01 = new Tile();
            tile00 = new Tile();
            boardPicture = new PictureBox();
            currentPlayerInfo = new Label();
            currentPlayerIndicator = new Tile();
            boardMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem1 = new ToolStripMenuItem();
            passButton = new Button();
            boardGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tile26).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile27).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile24).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile25).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile07).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile06).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile05).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile04).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile03).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile02).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile01).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tile00).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boardPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentPlayerIndicator).BeginInit();
            boardMenu.SuspendLayout();
            SuspendLayout();
            // 
            // boardGroup
            // 
            boardGroup.Controls.Add(tile26);
            boardGroup.Controls.Add(tile27);
            boardGroup.Controls.Add(tile20);
            boardGroup.Controls.Add(tile24);
            boardGroup.Controls.Add(tile23);
            boardGroup.Controls.Add(tile22);
            boardGroup.Controls.Add(tile21);
            boardGroup.Controls.Add(tile25);
            boardGroup.Controls.Add(tile14);
            boardGroup.Controls.Add(tile16);
            boardGroup.Controls.Add(tile15);
            boardGroup.Controls.Add(tile07);
            boardGroup.Controls.Add(tile17);
            boardGroup.Controls.Add(tile10);
            boardGroup.Controls.Add(tile11);
            boardGroup.Controls.Add(tile12);
            boardGroup.Controls.Add(tile13);
            boardGroup.Controls.Add(tile06);
            boardGroup.Controls.Add(tile05);
            boardGroup.Controls.Add(tile04);
            boardGroup.Controls.Add(tile03);
            boardGroup.Controls.Add(tile02);
            boardGroup.Controls.Add(tile01);
            boardGroup.Controls.Add(tile00);
            boardGroup.Controls.Add(boardPicture);
            boardGroup.Location = new Point(15, 41);
            boardGroup.Name = "boardGroup";
            boardGroup.Size = new Size(600, 600);
            boardGroup.TabIndex = 11;
            boardGroup.TabStop = false;
            // 
            // tile26
            // 
            tile26.BackColor = Color.FromArgb(255, 240, 195);
            tile26.Image = WinformsView.Properties.Resources.empty;
            tile26.Index = 6;
            tile26.Location = new Point(196, 344);
            tile26.Name = "tile26";
            tile26.Size = new Size(50, 50);
            tile26.SizeMode = PictureBoxSizeMode.Zoom;
            tile26.Square = 2;
            tile26.TabIndex = 37;
            tile26.TabStop = false;
            // 
            // tile27
            // 
            tile27.BackColor = Color.FromArgb(255, 240, 195);
            tile27.Image = WinformsView.Properties.Resources.empty;
            tile27.Index = 7;
            tile27.Location = new Point(196, 264);
            tile27.Name = "tile27";
            tile27.Size = new Size(50, 50);
            tile27.SizeMode = PictureBoxSizeMode.Zoom;
            tile27.Square = 2;
            tile27.TabIndex = 36;
            tile27.TabStop = false;
            // 
            // tile20
            // 
            tile20.BackColor = Color.FromArgb(255, 240, 195);
            tile20.Image = WinformsView.Properties.Resources.empty;
            tile20.Location = new Point(196, 191);
            tile20.Name = "tile20";
            tile20.Size = new Size(50, 50);
            tile20.SizeMode = PictureBoxSizeMode.Zoom;
            tile20.Square = 2;
            tile20.TabIndex = 35;
            tile20.TabStop = false;
            // 
            // tile24
            // 
            tile24.BackColor = Color.FromArgb(255, 240, 195);
            tile24.Image = WinformsView.Properties.Resources.empty;
            tile24.Index = 4;
            tile24.Location = new Point(345, 344);
            tile24.Name = "tile24";
            tile24.Size = new Size(50, 50);
            tile24.SizeMode = PictureBoxSizeMode.Zoom;
            tile24.Square = 2;
            tile24.TabIndex = 34;
            tile24.TabStop = false;
            // 
            // tile23
            // 
            tile23.BackColor = Color.FromArgb(255, 240, 195);
            tile23.Image = WinformsView.Properties.Resources.empty;
            tile23.Index = 3;
            tile23.Location = new Point(345, 264);
            tile23.Name = "tile23";
            tile23.Size = new Size(50, 50);
            tile23.SizeMode = PictureBoxSizeMode.Zoom;
            tile23.Square = 2;
            tile23.TabIndex = 33;
            tile23.TabStop = false;
            // 
            // tile22
            // 
            tile22.BackColor = Color.FromArgb(255, 240, 195);
            tile22.Image = WinformsView.Properties.Resources.empty;
            tile22.Index = 2;
            tile22.Location = new Point(345, 191);
            tile22.Name = "tile22";
            tile22.Size = new Size(50, 50);
            tile22.SizeMode = PictureBoxSizeMode.Zoom;
            tile22.Square = 2;
            tile22.TabIndex = 32;
            tile22.TabStop = false;
            // 
            // tile21
            // 
            tile21.BackColor = Color.FromArgb(255, 240, 195);
            tile21.Image = WinformsView.Properties.Resources.empty;
            tile21.Index = 1;
            tile21.Location = new Point(270, 191);
            tile21.Name = "tile21";
            tile21.Size = new Size(50, 50);
            tile21.SizeMode = PictureBoxSizeMode.Zoom;
            tile21.Square = 2;
            tile21.TabIndex = 31;
            tile21.TabStop = false;
            // 
            // tile25
            // 
            tile25.BackColor = Color.FromArgb(255, 240, 195);
            tile25.Image = WinformsView.Properties.Resources.empty;
            tile25.Index = 5;
            tile25.Location = new Point(270, 344);
            tile25.Name = "tile25";
            tile25.Size = new Size(50, 50);
            tile25.SizeMode = PictureBoxSizeMode.Zoom;
            tile25.Square = 2;
            tile25.TabIndex = 30;
            tile25.TabStop = false;
            // 
            // tile14
            // 
            tile14.BackColor = Color.FromArgb(255, 240, 195);
            tile14.Image = WinformsView.Properties.Resources.empty;
            tile14.Index = 4;
            tile14.Location = new Point(419, 417);
            tile14.Name = "tile14";
            tile14.Size = new Size(50, 50);
            tile14.SizeMode = PictureBoxSizeMode.Zoom;
            tile14.Square = 1;
            tile14.TabIndex = 29;
            tile14.TabStop = false;
            // 
            // tile16
            // 
            tile16.BackColor = Color.FromArgb(255, 240, 195);
            tile16.Image = WinformsView.Properties.Resources.empty;
            tile16.Index = 6;
            tile16.Location = new Point(122, 417);
            tile16.Name = "tile16";
            tile16.Size = new Size(50, 50);
            tile16.SizeMode = PictureBoxSizeMode.Zoom;
            tile16.Square = 1;
            tile16.TabIndex = 28;
            tile16.TabStop = false;
            // 
            // tile15
            // 
            tile15.BackColor = Color.FromArgb(255, 240, 195);
            tile15.Image = WinformsView.Properties.Resources.empty;
            tile15.Index = 5;
            tile15.Location = new Point(270, 417);
            tile15.Name = "tile15";
            tile15.Size = new Size(50, 50);
            tile15.SizeMode = PictureBoxSizeMode.Zoom;
            tile15.Square = 1;
            tile15.TabIndex = 27;
            tile15.TabStop = false;
            // 
            // tile07
            // 
            tile07.BackColor = Color.FromArgb(255, 240, 195);
            tile07.Image = WinformsView.Properties.Resources.empty;
            tile07.Index = 7;
            tile07.Location = new Point(46, 264);
            tile07.Name = "tile07";
            tile07.Size = new Size(50, 50);
            tile07.SizeMode = PictureBoxSizeMode.Zoom;
            tile07.TabIndex = 26;
            tile07.TabStop = false;
            // 
            // tile17
            // 
            tile17.BackColor = Color.FromArgb(255, 240, 195);
            tile17.Image = WinformsView.Properties.Resources.empty;
            tile17.Index = 7;
            tile17.Location = new Point(122, 264);
            tile17.Name = "tile17";
            tile17.Size = new Size(50, 50);
            tile17.SizeMode = PictureBoxSizeMode.Zoom;
            tile17.Square = 1;
            tile17.TabIndex = 25;
            tile17.TabStop = false;
            // 
            // tile10
            // 
            tile10.BackColor = Color.FromArgb(255, 240, 195);
            tile10.Image = WinformsView.Properties.Resources.empty;
            tile10.Location = new Point(122, 120);
            tile10.Name = "tile10";
            tile10.Size = new Size(50, 50);
            tile10.SizeMode = PictureBoxSizeMode.Zoom;
            tile10.Square = 1;
            tile10.TabIndex = 24;
            tile10.TabStop = false;
            // 
            // tile11
            // 
            tile11.BackColor = Color.FromArgb(255, 240, 195);
            tile11.Image = WinformsView.Properties.Resources.empty;
            tile11.Index = 1;
            tile11.Location = new Point(270, 120);
            tile11.Name = "tile11";
            tile11.Size = new Size(50, 50);
            tile11.SizeMode = PictureBoxSizeMode.Zoom;
            tile11.Square = 1;
            tile11.TabIndex = 23;
            tile11.TabStop = false;
            // 
            // tile12
            // 
            tile12.BackColor = Color.FromArgb(255, 240, 195);
            tile12.Image = WinformsView.Properties.Resources.empty;
            tile12.Index = 2;
            tile12.Location = new Point(419, 120);
            tile12.Name = "tile12";
            tile12.Size = new Size(50, 50);
            tile12.SizeMode = PictureBoxSizeMode.Zoom;
            tile12.Square = 1;
            tile12.TabIndex = 22;
            tile12.TabStop = false;
            // 
            // tile13
            // 
            tile13.BackColor = Color.FromArgb(255, 240, 195);
            tile13.Image = WinformsView.Properties.Resources.empty;
            tile13.Index = 3;
            tile13.Location = new Point(419, 264);
            tile13.Name = "tile13";
            tile13.Size = new Size(50, 50);
            tile13.SizeMode = PictureBoxSizeMode.Zoom;
            tile13.Square = 1;
            tile13.TabIndex = 21;
            tile13.TabStop = false;
            // 
            // tile06
            // 
            tile06.BackColor = Color.FromArgb(255, 240, 195);
            tile06.Image = WinformsView.Properties.Resources.empty;
            tile06.Index = 6;
            tile06.Location = new Point(46, 489);
            tile06.Name = "tile06";
            tile06.Size = new Size(50, 50);
            tile06.SizeMode = PictureBoxSizeMode.Zoom;
            tile06.TabIndex = 20;
            tile06.TabStop = false;
            // 
            // tile05
            // 
            tile05.BackColor = Color.FromArgb(255, 240, 195);
            tile05.Image = WinformsView.Properties.Resources.empty;
            tile05.Index = 5;
            tile05.Location = new Point(270, 489);
            tile05.Name = "tile05";
            tile05.Size = new Size(50, 50);
            tile05.SizeMode = PictureBoxSizeMode.Zoom;
            tile05.TabIndex = 19;
            tile05.TabStop = false;
            // 
            // tile04
            // 
            tile04.BackColor = Color.FromArgb(255, 240, 195);
            tile04.Image = WinformsView.Properties.Resources.empty;
            tile04.Index = 4;
            tile04.Location = new Point(493, 489);
            tile04.Name = "tile04";
            tile04.Size = new Size(50, 50);
            tile04.SizeMode = PictureBoxSizeMode.Zoom;
            tile04.TabIndex = 18;
            tile04.TabStop = false;
            // 
            // tile03
            // 
            tile03.BackColor = Color.FromArgb(255, 240, 195);
            tile03.Image = WinformsView.Properties.Resources.empty;
            tile03.Index = 3;
            tile03.Location = new Point(493, 264);
            tile03.Name = "tile03";
            tile03.Size = new Size(50, 50);
            tile03.SizeMode = PictureBoxSizeMode.Zoom;
            tile03.TabIndex = 17;
            tile03.TabStop = false;
            // 
            // tile02
            // 
            tile02.BackColor = Color.FromArgb(255, 240, 195);
            tile02.Image = WinformsView.Properties.Resources.empty;
            tile02.Index = 2;
            tile02.Location = new Point(493, 40);
            tile02.Name = "tile02";
            tile02.Size = new Size(50, 50);
            tile02.SizeMode = PictureBoxSizeMode.Zoom;
            tile02.TabIndex = 16;
            tile02.TabStop = false;
            // 
            // tile01
            // 
            tile01.BackColor = Color.FromArgb(255, 240, 195);
            tile01.Image = WinformsView.Properties.Resources.empty;
            tile01.Index = 1;
            tile01.Location = new Point(270, 40);
            tile01.Name = "tile01";
            tile01.Size = new Size(50, 50);
            tile01.SizeMode = PictureBoxSizeMode.Zoom;
            tile01.TabIndex = 15;
            tile01.TabStop = false;
            // 
            // tile00
            // 
            tile00.BackColor = Color.FromArgb(255, 240, 195);
            tile00.Image = WinformsView.Properties.Resources.empty;
            tile00.Location = new Point(46, 40);
            tile00.Name = "tile00";
            tile00.Size = new Size(50, 50);
            tile00.SizeMode = PictureBoxSizeMode.Zoom;
            tile00.TabIndex = 14;
            tile00.TabStop = false;
            // 
            // boardPicture
            // 
            boardPicture.BackColor = Color.FromArgb(255, 240, 195);
            boardPicture.Image = WinformsView.Properties.Resources.board;
            boardPicture.Location = new Point(0, 9);
            boardPicture.Name = "boardPicture";
            boardPicture.Size = new Size(589, 561);
            boardPicture.SizeMode = PictureBoxSizeMode.Zoom;
            boardPicture.TabIndex = 13;
            boardPicture.TabStop = false;
            // 
            // currentPlayerInfo
            // 
            currentPlayerInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentPlayerInfo.AutoSize = true;
            currentPlayerInfo.Location = new Point(77, 673);
            currentPlayerInfo.Name = "currentPlayerInfo";
            currentPlayerInfo.Size = new Size(162, 100);
            currentPlayerInfo.TabIndex = 12;
            currentPlayerInfo.Text = "Current Player: White\r\nStored Pieces: 9\r\nPlaced Pieces: 0\r\nGame State: Placement\r\n\r\n";
            // 
            // currentPlayerIndicator
            // 
            currentPlayerIndicator.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentPlayerIndicator.BackColor = Color.Transparent;
            currentPlayerIndicator.Image = WinformsView.Properties.Resources.empty;
            currentPlayerIndicator.Index = 5;
            currentPlayerIndicator.Location = new Point(15, 699);
            currentPlayerIndicator.Name = "currentPlayerIndicator";
            currentPlayerIndicator.Size = new Size(50, 50);
            currentPlayerIndicator.SizeMode = PictureBoxSizeMode.Zoom;
            currentPlayerIndicator.TabIndex = 20;
            currentPlayerIndicator.TabStop = false;
            // 
            // boardMenu
            // 
            boardMenu.ImageScalingSize = new Size(20, 20);
            boardMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, quitToolStripMenuItem, quitToolStripMenuItem1 });
            boardMenu.Location = new Point(0, 0);
            boardMenu.Name = "boardMenu";
            boardMenu.Size = new Size(627, 28);
            boardMenu.TabIndex = 21;
            boardMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(125, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += NewGame;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(125, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveGame;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(125, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadGame;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(64, 24);
            quitToolStripMenuItem.Text = "About";
            quitToolStripMenuItem.Click += About;
            // 
            // quitToolStripMenuItem1
            // 
            quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            quitToolStripMenuItem1.Size = new Size(51, 24);
            quitToolStripMenuItem1.Text = "Quit";
            quitToolStripMenuItem1.Click += Quit;
            // 
            // passButton
            // 
            passButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            passButton.Location = new Point(508, 720);
            passButton.Name = "passButton";
            passButton.Size = new Size(80, 29);
            passButton.TabIndex = 22;
            passButton.Text = "Pass";
            passButton.UseVisualStyleBackColor = true;
            passButton.Click += Pass;
            // 
            // BoardForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(627, 782);
            Controls.Add(passButton);
            Controls.Add(currentPlayerIndicator);
            Controls.Add(currentPlayerInfo);
            Controls.Add(boardGroup);
            Controls.Add(boardMenu);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "BoardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nine Men's Morris";
            boardGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tile26).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile27).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile20).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile24).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile23).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile22).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile21).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile25).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile14).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile16).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile15).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile07).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile17).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile10).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile11).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile12).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile13).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile06).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile05).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile04).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile03).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile02).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile01).EndInit();
            ((System.ComponentModel.ISupportInitialize)tile00).EndInit();
            ((System.ComponentModel.ISupportInitialize)boardPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentPlayerIndicator).EndInit();
            boardMenu.ResumeLayout(false);
            boardMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox boardGroup;
        private Tile tile02;
        private Tile tile01;
        private Tile tile00;
        private PictureBox boardPicture;
        private Tile tile12;
        private Tile tile13;
        private Tile tile06;
        private Tile tile05;
        private Tile tile04;
        private Tile tile03;
        private Tile tile26;
        private Tile tile27;
        private Tile tile20;
        private Tile tile24;
        private Tile tile23;
        private Tile tile22;
        private Tile tile21;
        private Tile tile25;
        private Tile tile14;
        private Tile tile16;
        private Tile tile15;
        private Tile tile07;
        private Tile tile17;
        private Tile tile10;
        private Tile tile11;
        private Label currentPlayerInfo;
        private Tile currentPlayerIndicator;
        private MenuStrip boardMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem1;
        private ToolStripMenuItem newToolStripMenuItem;
        private Button passButton;
    }
}
