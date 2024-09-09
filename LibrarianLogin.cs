using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryproject
{
    public partial class LibrarianLogin : Form
    {
        public LibrarianLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtpassword.Text;
            Librarian librarian = Database.getDocument<Librarian>(username, "Librarians");

            if (librarian != null)
            {
                if (librarian.login(username, password))
                {
                    new LibrarianDashboard(librarian).Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("The Username or Password you entered is incorrect, try again");
                    txtUserName.Clear();
                    txtpassword.Clear();
                    txtUserName.Focus();
                }
            }
            else
            {
                MessageBox.Show("The Username or Password you entered is incorrect, try again");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }

            //if (txtUserName.Text == "D" && txtpassword.Text == "2001")
            //{
            //    new LibrarianDashboard().Show();
            //        this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("The Username or Password you entered is incorrect, try again");
            //    txtUserName.Clear();
            //    txtpassword.Clear();
            //    txtUserName.Focus();
            //}



        }

        private void label6_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
