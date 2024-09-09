using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace libraryproject
{
    public class Librarian : User
    {
        //Book book;
        // Librarian class inherits from User class
        public Librarian(string name, string id, string password, string email, string contact) : base(name, id, password, email, contact)
        {

        }

        public void addBook(string isbn, string Name, string Authorname, string Publication, float Price)
        {
            // Add book to the library
            Book book = new Book(Name, isbn, Authorname, Publication, Price);

            // Add book to the database
            Database.insertDocument<Book>(book);
        }

        public void removeBook(Book book)
        {
            // Remove book from the database
            Database.deleteBook(book);
        }

        // Method to add a member to the library
        public void addMember(string id, string name, string password, string email, string contact)
        {
            // Add member to the database
            Member member = new Member(name, id, password, email, contact);
            Database.insertDocument<Member>(member);
        }

        // Method to remove a member from the library
        public void removeMember(string id)
        {
            // Remove member from the database
            Database.deleteDocument<Member>(id, "Members");
        }
    }
}
