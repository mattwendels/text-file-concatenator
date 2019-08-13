using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TextFileConcatenator
{
	public partial class MainForm : Form
	{
		private Rectangle _dragBoxFromMouseDown;

		private int _rowIndexFromMouseDown;
		private int _rowIndexOfItemUnderMouseToDrop;

        private bool _hasUnsavedChanges = false;

        private string _activeFileSetPath = null;
        private string _filesetFilter = "Text File Concatenator Fileset (*.tfcset)|*.tfcset";
        private string _scriptFilesFilter = "Script files (*.txt;*.sql;*.plpgsql)|*.txt;*.sql;*.plpgsql|";

        public MainForm(string file)
		{
			InitializeComponent();

			// Init some controls.
			fileDataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            saveFilesetDialog.Title = "Save File Set";
            saveFilesetDialog.Filter = _filesetFilter;
            saveFilesetDialog.DefaultExt = "tfcset";
            saveFilesetDialog.AddExtension = true;

            openFilesetDialog.Title = "Open File Set";

			if (!string.IsNullOrEmpty(file))
			{
				OpenFileSet(file);
			}
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                newFileSetToolStripMenuItem_Click(this, new EventArgs());

                return true;
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                openFileSetToolStripMenuItem_Click(this, new EventArgs());

                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                saveToolStripMenuItem_Click(this, new EventArgs());

                return true;
            }

            if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                saveAsToolStripMenuItem_Click(this, new EventArgs());

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Events

        private void fileDataGrid_MouseMove(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				// If the mouse moves outside the rectangle, start the drag.
				if (_dragBoxFromMouseDown != Rectangle.Empty
					&& !_dragBoxFromMouseDown.Contains(e.X, e.Y))
				{
					// Proceed with the drag and drop, passing in the list item.                    
					var dropEffect = fileDataGrid.DoDragDrop(
						fileDataGrid.Rows[_rowIndexFromMouseDown], DragDropEffects.Move);
				}
			}
		}

		private void fileDataGrid_MouseDown(object sender, MouseEventArgs e)
		{
			// Get the index of the item the mouse is below.
			_rowIndexFromMouseDown = fileDataGrid.HitTest(e.X, e.Y).RowIndex;

			if (_rowIndexFromMouseDown != -1)
			{
				// Remember the point where the mouse down occurred. The DragSize indicates the size that the mouse can move 
				// before a drag event should be started.                
				var dragSize = SystemInformation.DragSize;

				// Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
				_dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
			}
			else
			{
				// Reset the rectangle if the mouse is not over an item in the ListBox.
				_dragBoxFromMouseDown = Rectangle.Empty;
			}
		}

		private void fileDataGrid_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void fileDataGrid_DragDrop(object sender, DragEventArgs e)
		{
			// The mouse locations are relative to the screen, so they must be converted to client coordinates.
			var clientPoint = fileDataGrid.PointToClient(new Point(e.X, e.Y));

			// Get the row index of the item the mouse is below. 
			_rowIndexOfItemUnderMouseToDrop = fileDataGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			// If the drag operation was a move then remove and insert the row.
			if (e.Effect == DragDropEffects.Move)
			{
				var rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;

				if (_rowIndexOfItemUnderMouseToDrop > -1)
				{
					fileDataGrid.Rows.RemoveAt(_rowIndexFromMouseDown);
					fileDataGrid.Rows.Insert(_rowIndexOfItemUnderMouseToDrop, rowToMove);
				}
			}
		}

		private void selectFilesButton_Click(object sender, System.EventArgs e)
		{
			selectFilesDialog.Filter = _scriptFilesFilter + "All files (*.*)|*.*";

			selectFilesDialog.Multiselect = true;
			selectFilesDialog.Title = "Select text files";

			var dialogResult = selectFilesDialog.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
                SetUnsaved();

                foreach (var fileName in selectFilesDialog.FileNames)
				{
                    AddToDataGridList(fileName);

                }
			}
		}

        private void BtnBrowseFolders_Click(object sender, EventArgs e)
        {
            var dialogResult = selectFolderDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                SetUnsaved();

                foreach (var fileName in Directory.EnumerateFiles(selectFolderDialog.SelectedPath, "*.*", chkFolderSelectRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                {
                    AddToDataGridList(fileName);
                }
            }
        }

        private void exitButton_Click(object sender, System.EventArgs e)
		{
            if (ConfirmUnsavedChanges())
            {
                Close();
            }
		}

		private void fileDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			// Draw row numbers.
			var grid = sender as DataGridView;
			var rowIdx = (e.RowIndex + 1).ToString();

			var centerFormat = new StringFormat()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);

			e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
		}

		private void concatAndViewButton_Click(object sender, System.EventArgs e)
		{
			if (!IsFileSelectValid())
			{
				return;
			}

			var output = new ConcatOutput(ConcatFileContents());

			output.ShowDialog();
		}

		private void concatAndSaveButton_Click(object sender, EventArgs e)
		{
			if (!IsFileSelectValid())
			{
				return;
			}

			saveOutputFileDialog.Filter = "All files (*.*)|*.*";

			if (saveOutputFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.IO.File.WriteAllText(saveOutputFileDialog.FileName, ConcatFileContents());

					saveStatusLabel.Text = "Output file saved";

					Thread.Sleep(200);

					saveStatusLabel.Visible = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Failed to save concatenated file contents. Details: {ex}", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmUnsavedChanges())
            {
                Close();
            }
        }

        private void newFileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmUnsavedChanges())
            {
                fileDataGrid.Rows.Clear();
                fileDataGrid.Refresh();

                _hasUnsavedChanges = false;
                _activeFileSetPath = null;

                ActiveForm.Text = "Text File Concatenator";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFileSelectValid())
            {
                return;
            }

            if (string.IsNullOrEmpty(_activeFileSetPath))
            {
                if (saveFilesetDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileSet(saveFilesetDialog.FileName);
                }
            }
            else
            {
                SaveFileSet(_activeFileSetPath);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFilesetDialog.Reset();

            if (IsFileSelectValid() && saveFilesetDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileSet(saveFilesetDialog.FileName);
            }
        }

        private void openFileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveStatusLabel.Text = string.Empty;

            openFilesetDialog.Filter = _filesetFilter;
            openFilesetDialog.Multiselect = false;

            if (ConfirmUnsavedChanges() && openFilesetDialog.ShowDialog() == DialogResult.OK)
			{
				OpenFileSet(openFilesetDialog.FileName);
			}
		}

		private void fileDataGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SetUnsaved();
        }

        #endregion

        #region Private Methods

        private string ConcatFileContents()
		{
			var allText = new StringBuilder();

			foreach (DataGridViewRow row in fileDataGrid.Rows)
			{
				var fileName = row.Cells[0].Value.ToString();

				try
				{
					var fileContents = System.IO.File.ReadAllText(fileName);

					allText.AppendLine(fileContents);
					allText.AppendLine();
				}
				catch (Exception e)
				{
					MessageBox.Show($"Failed to read file contents of {fileName}. Details: {e}", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			return allText.ToString().Trim();
		}

		private bool IsFileSelectValid()
		{
			if (fileDataGrid.Rows.Count == 0)
			{
				MessageBox.Show("Please select one or more text files to concatenate.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			return true;
		}

        private bool ConfirmUnsavedChanges()
        {
            if (_hasUnsavedChanges)
            {
                return MessageBox.Show("Discard unsaved changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes;
            }

            return true;
        }

        private void SaveFileSet(string path)
        {
            saveStatusLabel.Visible = false;

            try
            {
                using (var writer = new StreamWriter(path, false))
                {
                    var files = new List<string>();

                    foreach (DataGridViewRow row in fileDataGrid.Rows)
                    {
                        files.Add(row.Cells[0].Value.ToString());
                    }

                    foreach (var file in files.Distinct())
                    {
                        writer.WriteLine(file);
                    }
                }

                _activeFileSetPath = path;

                _hasUnsavedChanges = false;

                ActiveForm.Text = $"Text File Concatenator - {path}";

                saveStatusLabel.Text = "File set saved";

                Thread.Sleep(200);

                saveStatusLabel.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to save fileset. Details: {e}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void OpenFileSet(string fileSetPath)
		{
			try
			{
				var files = System.IO.File.ReadAllLines(fileSetPath);

				fileDataGrid.Rows.Clear();
				fileDataGrid.Refresh();

				foreach (var file in files)
				{
					if (System.IO.File.Exists(file))
					{
						fileDataGrid.Rows.Add(file);
					}
					else
					{
						MessageBox.Show($"File not found '{file}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

				_activeFileSetPath = fileSetPath;

				if (ActiveForm != null)
				{
					ActiveForm.Text = $"Text File Concatenator - {fileSetPath}";
				}

				this.Text = $"Text File Concatenator - {fileSetPath}";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Failed to open file set. Details: {ex}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void SetUnsaved()
        {
            _hasUnsavedChanges = true;

            if (!string.IsNullOrWhiteSpace(_activeFileSetPath))
            {
                ActiveForm.Text = $"Text File Concatentor - {_activeFileSetPath}*";
            }
        }

        private void AddToDataGridList(string fileName)
        {
            concatAndSaveButton.Enabled = true;
            concatAndViewButton.Enabled = true;

            if (!fileDataGrid.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[0].Value.ToString() == fileName))
            {
                fileDataGrid.Rows.Add(fileName);
            }
        }

        #endregion
    }
}
