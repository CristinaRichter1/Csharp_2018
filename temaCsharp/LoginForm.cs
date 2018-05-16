using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using temaCsharp.Util;

/**
 * 
 * Allows user to log in
 * 
 */ 
namespace temaCsharp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /**
         * Returns whether the credentials entered matched those we had in the resources
         * 
         */ 
        public bool isLoginSuccess()
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            return loginForm.loginUserControl1.isLoggedIn;
        }

        private void loginUserControl1_Load(object sender, EventArgs e)
        {
        }

        /**
         * Shows default values for login credentials
         * 
         */ 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            String defaultUsername = "Admin";
            String defaultPassword = "password";
            HardwareUtil.showDefaultCredentials(
                String.Format("Default Username :  {0}\n\rDefault Password :  {1}", defaultUsername, defaultPassword)    
            );
        }
    }
}
