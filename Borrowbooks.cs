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
    public partial class Borrowbooks : Form
    {
        Member member;
        DataTable dt;

        public Borrowbooks(Member member)
        {
            InitializeComponent();
            this.member = member;
            dt = new DataTable();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtISBNno.Clear();
            txtBookname.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            member.borrowBook(txtISBNno.Text);
        }

        private void Borrowbooks_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            List<Book> books = Database.getAllDocuments<Book>();

            dt.Columns.Clear();

            dt.Columns.Add("ISBN");
            dt.Columns.Add("Title");
            dt.Columns.Add("Author");
            dt.Columns.Add("Publication");
            dt.Columns.Add("Price");
            dt.Columns.Add("Availability");

            if (books.Count > 0)
            {
                foreach (Book book in books)
                {
                    dt.Rows.Add(book.isbn, book.Name, book.Authorname, book.Publication, book.Price, book.Availability.ToString());
                }

            }

            dataGridView1.DataSource = dt;
        }
    }
}
