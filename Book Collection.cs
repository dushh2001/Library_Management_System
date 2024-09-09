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
    public partial class Book_Collection : Form
    {
        Member member;

        public Book_Collection(Member member)
        {
            InitializeComponent();
            this.member = member;
            bookTableLoad();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bookTableLoad()
        {
            List<Book> Books = member.showAllBooks();

            if (Books == null)
            {
                MessageBox.Show("No books available");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ISBN");
                dt.Columns.Add("Titel");
                dt.Columns.Add("Author");
                dt.Columns.Add("Publication");
                dt.Columns.Add("Price");

                foreach (Book book in Books)
                {
                    dt.Rows.Add(book.isbn, book.Name, book.Authorname, book.Publication, book.Price);
                }

                dataGridView1.DataSource = dt;

                this.Show();
            }
        }

        private void Book_Collection_Load(object sender, EventArgs e)
        {
            bookTableLoad();
        }
    }
}
