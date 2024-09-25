using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cart1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void login(Customer customer)//assigning username text and password to property username&password
        {
            customer.Username = username.Text;
            customer.Password = password.Text;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lgn_Click(object sender, EventArgs e)//login button
        {
            //Customer customer = new Customer();
            //login(customer);


            Database db = new Database();
            var check = db.CheckUserNameAndPassword(username.Text, password.Text);//checking username feild&password feild in db

           
                if (check)
                {
                    validationLabel.Text = "LoggedIn";
                    Itemsmenu itemsmenu = new Itemsmenu();
                    itemsmenu.Show(this);
                    this.Hide();
                }
                else if (db.CheckUserName(username.Text))
                {
                    //password is wrong
                    validationLabel.Text = "Incorrect Password";

                }
                else
                {    //username is wrong
                    validationLabel.Text = "UserName is incorrect";
                }
            
        }
        

        private bool checkUserName()//validation on username
        {
            var usernameFelid = username.Text;

            if (string.IsNullOrEmpty(username.Text))
            {
                usernameError.Text = "The username field shall not be empty";
                return false;
            }
            else if (username.Text.Length <= 7)
            {
                usernameError.Text = "Username must be at least 8 characters";
                return false;
            }
            usernameError.Text = "";
            return true;
        }
        private bool Checkpassword()//validation on password
        {

            if (string.IsNullOrEmpty(password.Text))
            {
                passwordError.Text = "The password field shall not be empty";
                return false;
            }
            else if (password.Text.Length <= 7)
            {
                passwordError.Text = "Password must be more than 8 characters";
                return false;
            }
            passwordError.Text = "";
            return true;
        }
        private void fname_TextChanged(object sender, EventArgs e)//username text feild
        {
            checkUserName();
        }

        private void signup_Login_Click(object sender, EventArgs e)// go to sign up form if no account exists
        {
          Form1 form1 = new Form1();      
            form1.Show(); 

        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void password_TextChanged(object sender, EventArgs e)//password text feild
        {
            Checkpassword();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
