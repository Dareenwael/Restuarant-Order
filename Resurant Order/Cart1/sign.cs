using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cart1
{
    public partial class Form1 : Form
    {
        private void Signup_Click(object sender, EventArgs e)
        {

            if (checkUserName() && Checkpassword())
            {
                Database db = new Database();
                //if username already present return validation error
                var check = db.CheckUserName(username.Text);

                if (check)
                {
                    //username taken
                    validationLabel.Text = "Username is used ";
                }
                else
                {
               
                    var Result=db.createUser(username.Text,pass.Text);
                    if (Result)
                    {
                        Itemsmenu itemsmenu = new Itemsmenu();
                        itemsmenu.Show(this);
                    }
                }
            }
        }
      
      public Form1()
      {
        InitializeComponent();
       }
     private void sign_in(Customer customer)
     {
         customer.UsernameS = username.Text;
         customer.Password = pass.Text;
     }


     private void label1_Click(object sender, EventArgs e)
     {

     }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void Password_TextChanged(object sender, EventArgs e)
    {

    }

private void label3_Click(object sender, EventArgs e)
{

}

private void UserName_TextChanged(object sender, EventArgs e)
{

}


private void Form1_Load(object sender, EventArgs e)
{

}

    private void pictureBox3_Click(object sender, EventArgs e)
    {
    Application.Exit();
    }

        private void Form1_Load_1(object sender, EventArgs e)
        {
         
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       
        private bool checkUserName()  //check usernamev
        {
            var usernameFieldText = username.Text;

            
            if (string.IsNullOrEmpty(username.Text)) //if it is empty
            {
                usernameError.Text = "The username field shall not be empty";
                return false;
            }
            //input field is less than 8 character
            else if (username.Text.Length <= 7)
            {
                usernameError.Text = "Username must be atleast 8 characters";
                return false;
            }
            usernameError.Text = "";
            return true;
        }

        private bool Checkpassword()
        {

            if (string.IsNullOrEmpty(pass.Text))// pass represent password text feild 
                                                //check passwordv
            {
                passwordError.Text = "The password field shall not be empty";
                return false;
            }
            else if (pass.Text.Length <= 7)
            {
                passwordError.Text = "Password must be atleast 8 characters";
                return false;
            }
            passwordError.Text = "";
            return true;
        }

        private void username_TextChanged_1(object sender, EventArgs e)
        {
            checkUserName();
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            Checkpassword();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_signup_Click_1(object sender, EventArgs e)//go to login form if acount already exists
        {
            new Login().Show();
            this.Hide();
            
        }
    }
}
