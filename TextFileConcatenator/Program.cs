using System;
using System.Linq;
using System.Windows.Forms;

namespace TextFileConcatenator
{
    static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();

			Application.SetCompatibleTextRenderingDefault(false);

			var fileOpened = args.Any() ? args[0] : null;

			Application.Run(new MainForm(fileOpened));
		}
	}
}
