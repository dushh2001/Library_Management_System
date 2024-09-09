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
    public partial class MemberLogin : Form
    {
        public MemberLogin()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            //if (txtUserName.Text == "D" && txtpassword.Text == "2001")
            //{
            //    new MemberDashboard().Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("The Username or Password you entered is incorrect, try again");
            //    txtUserName.Clear();
            //    txtpassword.Clear();
            //    txtUserName.Focus();
            //}

            string username = txtUserName.Text;
            string password = txtpassword.Text;
            Member member = Database.getDocument<Member>(username, "Members");

            if (member != null)
            {
                if (member.login(username, password))
                {
                    new MemberDashboard(member).Show();
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
        }

        private void label6_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }
    }
}
