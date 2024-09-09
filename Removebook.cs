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
    public partial class Removebook : Form
    {
        Librarian librarian;
        public Removebook(Librarian librarian)
        {
            InitializeComponent();
            this.librarian = librarian;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtisbn.Clear();
            txtbook.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string isbn = this.txtisbn.Text;
            string title = this.txtbook.Text;
            if (isbn.Trim() != "" && title.Trim() != "")
            {
                Book book = Database.getBookByISBN(this.txtisbn.Text);

                if (book != null)
                {
                    Database.deleteBook(book);
                    MessageBox.Show("Book removed successfully!");
                    loadTable();
                }
                else
                {
                    MessageBox.Show("Book not found!");
                }
            }
            else { MessageBox.Show("Please fill all the fields"); }

        }
        private void loadTable()
        {
            List<Book> books = Database.getAllDocuments<Book>();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ISBN");
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Author");
            dataTable.Columns.Add("Publication");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Availability");

            foreach (Book book in books)
            {
                dataTable.Rows.Add(book.isbn, book.Name, book.Authorname, book.Publication, book.Price, book.Availability);
            }

            dataGridView1.DataSource = dataTable;
        }

        private void Removebook_Load(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
