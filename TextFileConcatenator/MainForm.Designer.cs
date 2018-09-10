namespace TextFileConcatenator
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.fileDataGrid = new System.Windows.Forms.DataGridView();
			this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.selectFilesLabel = new System.Windows.Forms.Label();
			this.selectFilesButton = new System.Windows.Forms.Button();
			this.selectFilesDialog = new System.Windows.Forms.OpenFileDialog();
			this.concatAndSaveButton = new System.Windows.Forms.Button();
			this.concatAndViewButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.reOrderLabel = new System.Windows.Forms.Label();
			this.saveOutputFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.fileMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newFileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFilesetDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFilesetDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveStatusLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fileDataGrid)).BeginInit();
			this.fileMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// fileDataGrid
			// 
			this.fileDataGrid.AllowDrop = true;
			this.fileDataGrid.AllowUserToAddRows = false;
			this.fileDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fileDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.fileDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File});
			this.fileDataGrid.Location = new System.Drawing.Point(10, 96);
			this.fileDataGrid.Name = "fileDataGrid";
			this.fileDataGrid.ReadOnly = true;
			this.fileDataGrid.Size = new System.Drawing.Size(878, 252);
			this.fileDataGrid.TabIndex = 0;
			this.fileDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.fileDataGrid_RowPostPaint);
			this.fileDataGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.fileDataGrid_UserDeletedRow);
			this.fileDataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDataGrid_DragDrop);
			this.fileDataGrid.DragOver += new System.Windows.Forms.DragEventHandler(this.fileDataGrid_DragOver);
			this.fileDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileDataGrid_MouseDown);
			this.fileDataGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fileDataGrid_MouseMove);
			// 
			// File
			// 
			this.File.HeaderText = "File";
			this.File.Name = "File";
			this.File.ReadOnly = true;
			// 
			// selectFilesLabel
			// 
			this.selectFilesLabel.AutoSize = true;
			this.selectFilesLabel.Location = new System.Drawing.Point(10, 40);
			this.selectFilesLabel.Name = "selectFilesLabel";
			this.selectFilesLabel.Size = new System.Drawing.Size(67, 13);
			this.selectFilesLabel.TabIndex = 1;
			this.selectFilesLabel.Text = "Select file(s):";
			// 
			// selectFilesButton
			// 
			this.selectFilesButton.Location = new System.Drawing.Point(86, 35);
			this.selectFilesButton.Name = "selectFilesButton";
			this.selectFilesButton.Size = new System.Drawing.Size(75, 23);
			this.selectFilesButton.TabIndex = 2;
			this.selectFilesButton.Text = "Browse...";
			this.selectFilesButton.UseVisualStyleBackColor = true;
			this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
			// 
			// concatAndSaveButton
			// 
			this.concatAndSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.concatAndSaveButton.Location = new System.Drawing.Point(10, 359);
			this.concatAndSaveButton.Name = "concatAndSaveButton";
			this.concatAndSaveButton.Size = new System.Drawing.Size(167, 23);
			this.concatAndSaveButton.TabIndex = 3;
			this.concatAndSaveButton.Text = "Concat and Save to File";
			this.concatAndSaveButton.UseVisualStyleBackColor = true;
			this.concatAndSaveButton.Click += new System.EventHandler(this.concatAndSaveButton_Click);
			// 
			// concatAndViewButton
			// 
			this.concatAndViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.concatAndViewButton.Location = new System.Drawing.Point(185, 359);
			this.concatAndViewButton.Name = "concatAndViewButton";
			this.concatAndViewButton.Size = new System.Drawing.Size(124, 23);
			this.concatAndViewButton.TabIndex = 4;
			this.concatAndViewButton.Text = "Concat and View";
			this.concatAndViewButton.UseVisualStyleBackColor = true;
			this.concatAndViewButton.Click += new System.EventHandler(this.concatAndViewButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(812, 359);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 5;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// reOrderLabel
			// 
			this.reOrderLabel.AutoSize = true;
			this.reOrderLabel.Location = new System.Drawing.Point(10, 67);
			this.reOrderLabel.Name = "reOrderLabel";
			this.reOrderLabel.Size = new System.Drawing.Size(233, 13);
			this.reOrderLabel.TabIndex = 6;
			this.reOrderLabel.Text = "Drag and drop selected text file rows to re-order.";
			// 
			// fileMenuStrip
			// 
			this.fileMenuStrip.BackColor = System.Drawing.SystemColors.Window;
			this.fileMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.fileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.fileMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.fileMenuStrip.Name = "fileMenuStrip";
			this.fileMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.fileMenuStrip.Size = new System.Drawing.Size(897, 24);
			this.fileMenuStrip.TabIndex = 7;
			this.fileMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileSetToolStripMenuItem,
            this.openFileSetToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newFileSetToolStripMenuItem
			// 
			this.newFileSetToolStripMenuItem.Name = "newFileSetToolStripMenuItem";
			this.newFileSetToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.newFileSetToolStripMenuItem.Text = "New File Set (Ctrl+N)";
			this.newFileSetToolStripMenuItem.Click += new System.EventHandler(this.newFileSetToolStripMenuItem_Click);
			// 
			// openFileSetToolStripMenuItem
			// 
			this.openFileSetToolStripMenuItem.Name = "openFileSetToolStripMenuItem";
			this.openFileSetToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.openFileSetToolStripMenuItem.Text = "Open File Set (Ctrl+O)";
			this.openFileSetToolStripMenuItem.Click += new System.EventHandler(this.openFileSetToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.saveToolStripMenuItem.Text = "Save File Set (Ctrl+S)";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.saveAsToolStripMenuItem.Text = "Save File Set As... (Ctrl+Shift+S)";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// saveStatusLabel
			// 
			this.saveStatusLabel.AutoSize = true;
			this.saveStatusLabel.ForeColor = System.Drawing.Color.Green;
			this.saveStatusLabel.Location = new System.Drawing.Point(325, 364);
			this.saveStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.saveStatusLabel.Name = "saveStatusLabel";
			this.saveStatusLabel.Size = new System.Drawing.Size(35, 13);
			this.saveStatusLabel.TabIndex = 8;
			this.saveStatusLabel.Text = "label1";
			this.saveStatusLabel.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 392);
			this.Controls.Add(this.saveStatusLabel);
			this.Controls.Add(this.reOrderLabel);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.concatAndViewButton);
			this.Controls.Add(this.concatAndSaveButton);
			this.Controls.Add(this.selectFilesButton);
			this.Controls.Add(this.selectFilesLabel);
			this.Controls.Add(this.fileDataGrid);
			this.Controls.Add(this.fileMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Text File Concatenator";
			((System.ComponentModel.ISupportInitialize)(this.fileDataGrid)).EndInit();
			this.fileMenuStrip.ResumeLayout(false);
			this.fileMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView fileDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn File;
		private System.Windows.Forms.Label selectFilesLabel;
		private System.Windows.Forms.Button selectFilesButton;
		private System.Windows.Forms.OpenFileDialog selectFilesDialog;
		private System.Windows.Forms.Button concatAndSaveButton;
		private System.Windows.Forms.Button concatAndViewButton;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Label reOrderLabel;
		private System.Windows.Forms.SaveFileDialog saveOutputFileDialog;
        private System.Windows.Forms.MenuStrip fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFilesetDialog;
        private System.Windows.Forms.OpenFileDialog openFilesetDialog;
        private System.Windows.Forms.Label saveStatusLabel;
    }
}

