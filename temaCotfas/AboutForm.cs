using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temaCsharp
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            // Pull the About text from resource file -- it shoud contain a hyperlink,
            // therefore attach appropriate event handler as well
            String text = AboutResource.About;
            richTextBox1.Text = text;
            richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_Clicked);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Clicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
