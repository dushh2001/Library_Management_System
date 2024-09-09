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
    public partial class LibrarianDashboard : Form
    {   
        Librarian librarian;
        public LibrarianDashboard(Librarian librarian)
        {
            InitializeComponent();
            this.librarian = librarian;
        }

        private void LibrarianDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Addbook(librarian).Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Removemember(librarian).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Removebook(librarian).Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddMember(librarian).Show();
            
        }
    }
}
