namespace TextFileConcatenator
{
	partial class ConcatOutput
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcatOutput));
			this.outputTextArea = new System.Windows.Forms.RichTextBox();
			this.copyToClipboardButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.copyToClipboardLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// outputTextArea
			// 
			this.outputTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputTextArea.BackColor = System.Drawing.SystemColors.Window;
			this.outputTextArea.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputTextArea.Location = new System.Drawing.Point(12, 12);
			this.outputTextArea.Name = "outputTextArea";
			this.outputTextArea.ReadOnly = true;
			this.outputTextArea.Size = new System.Drawing.Size(776, 426);
			this.outputTextArea.TabIndex = 0;
			this.outputTextArea.Text = "";
			// 
			// copyToClipboardButton
			// 
			this.copyToClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.copyToClipboardButton.Location = new System.Drawing.Point(12, 444);
			this.copyToClipboardButton.Name = "copyToClipboardButton";
			this.copyToClipboardButton.Size = new System.Drawing.Size(115, 23);
			this.copyToClipboardButton.TabIndex = 1;
			this.copyToClipboardButton.Text = "Copy to Clipboard";
			this.copyToClipboardButton.UseVisualStyleBackColor = true;
			this.copyToClipboardButton.Click += new System.EventHandler(this.copyToClipboardButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(713, 444);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// copyToClipboardLabel
			// 
			this.copyToClipboardLabel.AutoSize = true;
			this.copyToClipboardLabel.ForeColor = System.Drawing.Color.Green;
			this.copyToClipboardLabel.Location = new System.Drawing.Point(133, 449);
			this.copyToClipboardLabel.Name = "copyToClipboardLabel";
			this.copyToClipboardLabel.Size = new System.Drawing.Size(0, 13);
			this.copyToClipboardLabel.TabIndex = 3;
			// 
			// ConcatOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 478);
			this.Controls.Add(this.copyToClipboardLabel);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.copyToClipboardButton);
			this.Controls.Add(this.outputTextArea);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConcatOutput";
			this.Text = "Output";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox outputTextArea;
		private System.Windows.Forms.Button copyToClipboardButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label copyToClipboardLabel;
	}
}