using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cart1
{
    internal class Customer
    {
        public Customer()
        {
            username = "";
            password = "";
        }
        private string usernameS;//usernname for sign in
        public string UsernameS
        {
            get; set;
        }
      
        private string username;
        public string Username
        {
            get; set;
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                if (password.Length < 8)
                {
                    MessageBox.Show("password cannot be less the 8");
                    password = "";
                }

            }

        }


    }
}
