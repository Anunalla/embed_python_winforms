using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Python.Runtime;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        
        private dynamic my_data = null;  // object to store the data read from the file opened
        private dynamic numpy_lib = null; // object to hold the imported Numpy Library

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // import Numpy when form is loaded
            using (Py.GIL())
            {
                numpy_lib = Py.Import("numpy");
            }

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // opens file explorer and allows selection of .npy file 
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "npy",
                Filter = "npy files (*.npy)|*.npy",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            // when a .npy file is selected, use python to read the files
           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String select_file = openFileDialog1.FileName;
                using(Py.GIL())
                {


                    my_data = numpy_lib.load(select_file);  // read the file's data
                    Console.WriteLine(my_data);  // print data to console
                    // TODO: Insert a data viewer table to the form to display the data.

                }
                
                Console.WriteLine(select_file); // print the file's path to console (for debugging purposes)
            }
        }
    }
}
