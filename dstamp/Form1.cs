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
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Initialize and start the timer
            timer = new Timer();
            timer.Interval = 500; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();

            // Update label immediately on startup
            UpdateTimestampLabel();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimestampLabel();
        }

        private void UpdateTimestampLabel()
        {
            string format = textBoxFormat.Text;
            try
            {
                string timestamp = DateTime.Now.ToString(format);
                labelTimestamp.Text = $"{timestamp}";
            }
            catch (Exception ex)
            {
                labelTimestamp.Text = $"Error: {ex.Message}";
            }
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
            string prefix = DateTime.Now.ToString(textBoxFormat.Text);

            foreach (string input in filePaths)
            {
                string name = Path.GetFileName(input);
                string path = Path.GetDirectoryName(input);
                string new_name = path + '\\' + prefix + "_" + name;

                string message = $"Rename\n{name}\nto\n{prefix}_{name}?";
                DialogResult dialogResult = MessageBox.Show(this, message, "Rename File", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    continue; // skip to the next file if not confirmed
                }
                System.IO.File.Move(input, new_name);
            }
        }
    }
}
