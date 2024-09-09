using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace libraryproject
{
    public partial class Addbook : Form
    {
        Librarian librarian;
        public Addbook(Librarian librarian)
        {
            InitializeComponent();
            this.librarian = librarian;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Addbook_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string isbn = this.txtISBNno.Text.Trim();
                string title = this.txtBookname.Text.Trim();
                string author = this.txtBookauthorname.Text.Trim();
                string publication = this.txtBookpublication.Text.Trim();
                int price = int.Parse(this.txtBookprice.Text.Trim());
                if (isbn != "" && title != "" && author != "" && publication != "")
                {
                    librarian.addBook(this.txtISBNno.Text, this.txtBookname.Text, this.txtBookauthorname.Text, this.txtBookpublication.Text, float.Parse(txtBookprice.Text));
                }
                else 
                { 
                    MessageBox.Show("Please fill all the fields"); 
                }
            }
            catch
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtISBNno.Clear();
            txtBookname.Clear();
            txtBookauthorname.Clear();
            txtBookpublication.Clear();
            txtBookprice.Clear();
        }
    }
}
