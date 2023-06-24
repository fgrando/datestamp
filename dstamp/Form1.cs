using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dstamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void form_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // set prefix datetime format
            string prefix = DateTime.Now.ToString(radioButton1.Text);
            if (radioButton2.Checked)
                prefix = DateTime.Now.ToString(radioButton2.Text);
            if (radioButton3.Checked)
                prefix = DateTime.Now.ToString(textBox1.Text);

            foreach (string input in filePaths)
            {
                string name = Path.GetFileName(input);
                string path = Path.GetDirectoryName(input);
                string new_name = path + '\\' + prefix + "_" + name;
                
                Console.WriteLine("Rename " + input + " to " + new_name);
                System.IO.File.Move(input, new_name);
                //System.Windows.Forms.MessageBox.Show(new_name);
            }

            Close();
        }
    }
}
