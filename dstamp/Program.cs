using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace dstamp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            
            List<string> filepaths = new List<string>(arguments);
            filepaths.RemoveAt(0);

            string prefix = DateTime.Now.ToString("yyy.MM.dd_");
            foreach (string input in filepaths)
            {
                string name = Path.GetFileName(input);
                string path = Path.GetDirectoryName(input);
                string new_name = path + '\\' + prefix + '_' + name;

                Console.WriteLine("Rename " + input + " to " + new_name);
                System.IO.File.Move(input, new_name);
                System.Windows.Forms.MessageBox.Show("Rename " + input + " to " + new_name);

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
