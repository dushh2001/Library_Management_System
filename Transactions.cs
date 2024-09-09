using MongoDB.Driver.Core.Operations;
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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void BookCollection_Load(object sender, EventArgs e)
        {
            loadTransactions();
        }

        public void loadTransactions()
        {
            List<Transaction> transactions = Database.getAllDocuments<Transaction>();

            flowLayoutPanel1.Controls.Clear();
            int count = 0;
            foreach (Transaction transaction in transactions)
            {
                count++;
                transactionCard card = new transactionCard(transaction);
                card.count.Text = count.ToString();
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
