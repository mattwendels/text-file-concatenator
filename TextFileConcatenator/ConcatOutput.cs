using System.Threading;
using System.Windows.Forms;

namespace TextFileConcatenator
{
	public partial class ConcatOutput : Form
	{
		public ConcatOutput(string output)
		{
			InitializeComponent();

			outputTextArea.Text = output;
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void copyToClipboardButton_Click(object sender, System.EventArgs e)
		{
			copyToClipboardLabel.Visible = false;
			copyToClipboardLabel.Text = "Copied";

			outputTextArea.SelectAll();
			outputTextArea.Focus();

			Clipboard.SetText(outputTextArea.Text);

			Thread.Sleep(200);

			copyToClipboardLabel.Visible = true;
		}
	}
}
