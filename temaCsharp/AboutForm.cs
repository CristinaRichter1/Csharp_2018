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
            String link = AboutResource.GitLink;
            label1.Text = text;
            linkLabel1.Text = link;
            linkLabel1.Links[0].LinkData = link;
            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_Clicked);
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

        private void linkLabel1_Clicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData as string;
            System.Diagnostics.Process.Start(target);
            linkLabel1.LinkVisited = true;
        }
    }
}
