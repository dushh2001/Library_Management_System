using libraryproject;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

public class Member : User
{
    List<Book> borrowedBooks;

    public Member(string name, string id, string password, string email, string contact) : base(name, id, password, email, contact)
    {
        BorrowedBooks = new List<Book>();
    }

    public List<Book> BorrowedBooks
    {
        get { return borrowedBooks; }
        set { borrowedBooks = value; }
    }

    public List<Book> showAllBooks()
    {
        List<Book> books = Database.getAllDocuments<Book>();
        return books;
    }

    public void borrowBook(string isbn)
    {
        Book book = Database.getBookByISBN(isbn);
        if (book != null && book.Availability && !this.borrowedBooks.Exists(b => b.isbn == isbn))
        {
            book.Availability = false;
            borrowedBooks.Add(book);
            Database.updateBookAvailability(isbn, false);
            Database.updateDocument<Member>(this.Id, this, "Members");
            MessageBox.Show("Book borrowed successfully");
            Transaction transaction = new Transaction(book.isbn,this.Id, this.Name, "Borrow", DateTime.Now);
            Database.insertDocument<Transaction>(transaction);
        }
        else
        {
            MessageBox.Show("Book is not available or book not found");
        }
    }    

    public void returnBook(string isbn)
    {
        Book book = Database.getBookByISBN(isbn);
        if (book != null && this.borrowedBooks.Exists(b => b.isbn == isbn))
        {
            book.Availability = true;
            borrowedBooks.RemoveAll(b => b.isbn == book.isbn);
            Database.updateBookAvailability(isbn, true);
            Database.updateDocument<Member>(this.Id, this, "Members");
            MessageBox.Show("Book returned successfully");
            Transaction transaction = new Transaction(book.isbn, this.Id, this.Name, "Return", DateTime.Now);
            Database.insertDocument<Transaction>(transaction);
        }
        else
        {
            MessageBox.Show("Book haven't borrowed!");
        }
    }

}
