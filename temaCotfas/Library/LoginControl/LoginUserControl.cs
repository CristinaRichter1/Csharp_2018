using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginUserControl.Util;
using temaCsharp.Library.LoginControl;

namespace LoginUserControl
{
    public partial class LoginUserControl : UserControl
    {
        public bool isLoggedIn {get; set;}
        public int loginCount;

        public LoginUserControl()
        {
            InitializeComponent();
            loginCount = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool verifyCredentials(string userName, string password)
        {
            return (
                userName == LoginUserControlResource.DefaultUsername &&
                LoginUserControlUtil.CalculateMD5Hash(password) == LoginUserControlResource.DefaultPassword
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            if (verifyCredentials(userName, password))
            {
                isLoggedIn = true;
                button1.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Incorrect credentials!", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isLoggedIn = false;
                loginCount++;
                button1.DialogResult = DialogResult.Cancel;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
