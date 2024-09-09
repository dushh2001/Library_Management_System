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
    public partial class Returnbook : Form
    {
        Member member;
        DataTable dt;

        public Returnbook(Member member)
        {
            InitializeComponent();
            this.member = member;   
            dt = new DataTable();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtISBNno.Clear();
            txtBookname.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            member.returnBook(txtISBNno.Text);
            loadData();
        }

        private void loadData()
        {

            dt.Columns.Clear();

            dt.Columns.Add("ISBN");
            dt.Columns.Add("Title");
            dt.Columns.Add("Author");
            dt.Columns.Add("Publication");
            dt.Columns.Add("Price");
            dt.Columns.Add("Availability");

            List<Book> books = member.BorrowedBooks;

            foreach (Book book in books)
            {
                dt.Rows.Add(book.isbn, book.Name, book.Authorname, book.Publication, book.Price, book.Availability.ToString());
            }
            dataGridView1.DataSource = dt;
        }

        private void Returnbook_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
