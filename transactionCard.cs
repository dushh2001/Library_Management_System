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
    public partial class transactionCard : UserControl
    {
        Transaction transaction;

        public transactionCard(Transaction transaction)
        {
            InitializeComponent();
            this.transaction = transaction;
        }

        private void transactionCard_Load(object sender, EventArgs e)
        {
            id.Text = transaction.Id;
            type.Text = transaction.TransactionType;
            date.Text = transaction.Date.ToString();
            memID.Text = transaction.MemberID;
            memName.Text = transaction.MemberName;
            isbn.Text = transaction.BookISBN;
        }
    }
}
