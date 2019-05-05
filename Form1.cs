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

        
        private dynamic my_data = null;
        private dynamic numpy_lib = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String select_file = openFileDialog1.FileName;
                using(Py.GIL())
                {


                    my_data = numpy_lib.load(select_file);
                    Console.WriteLine(my_data);

                }
                
                Console.WriteLine(select_file);
            }
        }

        /*

        private String CreatePyScript(String fileName)
        {
            String result = "";
            string[] lines =
            {
                @"import numpy as np",
                @"def read_file(fileName):",
                @"  data = np.load(fileName)",
                @"  return data",
                @"",
            };
            result = String.Join("\r", lines);
            return result;
        }

        

        private Double execute_python_inline(String my_code)
        {
            ScriptSource source = pyEngine.CreateScriptSourceFromString(my_code, SourceCodeKind.Statements);
            CompiledCode compiled = source.Compile();
            Double py_result = compiled.Execute(pyScope);
            return py_result;
        }*/
    }
}
