using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Shows the logged error/warning data 
 * 
 */ 
namespace temaCsharp
{
    public partial class LogsForm : Form
    {
        public LogsForm()
        {
            InitializeComponent();
        }

        public LogsForm(String textBoxText)
        {
            InitializeComponent();
            textBox1.Lines = textBoxText.Split('\n');
            // little hack to prevent the ugly autoselection the form gains upon focus
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
