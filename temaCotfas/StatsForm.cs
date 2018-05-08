using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using temaCsharp.Library.Entities;

namespace temaCsharp
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
        }

        public StatsForm(PieChartCategory[] data)
        {
            InitializeComponent();
            pieChartControl1.Data = data;
        }
        
        private void StatsForm_Load(object sender, EventArgs e)
        {

        }

        private void pieChartControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
