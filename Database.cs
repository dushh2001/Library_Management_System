using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libraryproject;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

static class Database
{
    static IMongoClient client = new MongoClient();

    static IMongoDatabase db = client.GetDatabase("Library");

    static IMongoCollection<Book> books = db.GetCollection<Book>("Books");
    static IMongoCollection<Librarian> librarians = db.GetCollection<Librarian>("Librarians");
    static IMongoCollection<Member> members = db.GetCollection<Member>("Members");
    static IMongoCollection<Transaction> transacgions = db.GetCollection<Transaction>("Transactions");

    // Method to get book by isbn
    public static Book getBookByISBN(string isbn)
    {
        return books.Find(Builders<Book>.Filter.Eq("isbn", isbn)).FirstOrDefault();
    }

    // Method to insert a document into a collection
    public static void insertDocument<T>(T document)
    {
        if (document is Book)
        {
            try
            {
                books.InsertOne(document as Book);
                MessageBox.Show("Book added successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Book already exists");
            }
        }
        else if (document is Librarian)
        {
            try
            {
                librarians.InsertOne(document as Librarian);
                MessageBox.Show("Librarian added successfully");

            }
            catch (Exception)
            {
                MessageBox.Show("Librarian already exists");
            }
        }
        else if (document is Member)
        {
            try
            {
                members.InsertOne(document as Member);
                MessageBox.Show("Member added successfully");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        else if (document is Transaction)
        {
            try
            {
                transacgions.InsertOne(document as Transaction);
                MessageBox.Show("Transaction added successfully");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

    // Method to get all documents from a collection
    public static List<T> getAllDocuments<T>()
    {
        if (typeof(T) == typeof(Book))
        {
            try
            {
                return books.Find(_ => true).ToList() as List<T>;
            }
            catch (Exception)
            {
                MessageBox.Show("No books found");
            }
        }
        else if (typeof(T) == typeof(Librarian))
        {
            try
            {
                return librarians.Find(_ => true).ToList() as List<T>;
            }
            catch
            {
                MessageBox.Show("No librarians found");
            }
        }
        else if (typeof(T) == typeof(Member))
        {
            try
            {
                return members.Find(_ => true).ToList() as List<T>;
            }
            catch
            {
                MessageBox.Show("No members found");
            }
        }
        else if (typeof(T) == typeof(Transaction))
        {
            try
            {
                return transacgions.Find(_ => true).ToList() as List<T>;
            }
            catch
            {
                MessageBox.Show("No transactions found");
            }
        }
        return null;
    }

    // Method to get a document from a collection
    public static T getDocument<T>(string id, string collection)
    {
        return db.GetCollection<T>(collection).Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefault();
    }

    // Method to update a document in a collection
    public static void updateDocument<T>(string id, T document, string collection)
    {
        db.GetCollection<T>(collection).ReplaceOne(Builders<T>.Filter.Eq("Id", id), document);
    }

    public static void updateBookAvailability(string isbn, bool availability)
    {
        Book book = getBookByISBN(isbn);
        book.Availability = availability;
        //updateDocument<Book>(isbn, book, "Books");
        books.ReplaceOne(Builders<Book>.Filter.Eq("isbn", isbn), book);
    }

    // Method to delete a document from a collection
    public static void deleteDocument<T>(string id, string collection)
    {
        try
        {
            db.GetCollection<T>(collection).DeleteOne(Builders<T>.Filter.Eq("Id", id));
        }
        catch
        {
            MessageBox.Show("Document not found");
        }
    }

    public static void deleteBook(Book book)
    {
        try
        {
            db.GetCollection<Book>("Books").DeleteOne(Builders<Book>.Filter.Eq("isbn", book.isbn));
        }
        catch
        {
            MessageBox.Show("Document not found");
        }
    }
}
