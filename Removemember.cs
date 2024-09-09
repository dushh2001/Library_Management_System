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
    public partial class Removemember : Form
    {
        Librarian librarian;
        public Removemember(Librarian librarian)
        {
            InitializeComponent();
            this.librarian = librarian;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtBookquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtmembershipid.Clear();
            txtmember.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string membershipid = txtmembershipid.Text;
            string member = txtmember.Text;

            if (membershipid.Trim() != "" && member.Trim() != "")
            {
                Member mem = Database.getDocument<Member>(txtmembershipid.Text, "Members");
                if (mem != null)
                {
                    librarian.removeMember(txtmembershipid.Text);
                    MessageBox.Show("Member removed successfully");
                    loadTable();
                }
                else
                {
                    MessageBox.Show("Member not found");
                }
            }
            else { MessageBox.Show("Please fill all the fields"); }
        }

        private void Removemember_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            List<Member> members = Database.getAllDocuments<Member>();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Membership ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Contact");

            foreach (Member member in members)
            {
                dataTable.Rows.Add(member.Id, member.Name, member.Email, member.Contact);
            }

            dataGridView1.DataSource = dataTable;
        }
    }
}
