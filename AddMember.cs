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
    public partial class AddMember : Form
    {
        Librarian librarian;
        public AddMember(Librarian librarian)
        {
            InitializeComponent();
            this.librarian = librarian;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtmemid.Clear();
            txtmemname.Clear();
            txtmememail.Clear();
            txtmemcontact.Clear();
            txtmempassword.Clear();

        }

        private void txtBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtmemid.Text;
            string name = txtmemname.Text;
            string password = txtLoginPassword.Text;
            string email = txtmememail.Text;
            string contact = txtmemcontact.Text;
            
            if (id.Trim() == "" || name.Trim() == "" || password.Trim() == "" || email.Trim() == "" || contact.Trim() == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                librarian.addMember(txtmemid.Text, txtmemname.Text, txtmempassword.Text, txtmememail.Text, txtmemcontact.Text);
            }
        }

        private void AddMember_Load(object sender, EventArgs e)
        {

        }
    }
}
