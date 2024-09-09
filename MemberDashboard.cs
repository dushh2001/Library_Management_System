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
    public partial class MemberDashboard : Form
    {
        Member member;
        public MemberDashboard(Member member)
        {
            InitializeComponent();
            this.member = member;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Borrowbooks(member).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             new Returnbook(member).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Book_Collection(member);
        }
    }
}
