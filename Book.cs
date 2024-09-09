using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryproject
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        string ISBN;
        string title;
        string authorName;
        string publication;
        float price;
        bool availability;

        public Book(string title, string iSBN, string authorName, string publication, float price)
        {
            this.title = title;
            this.ISBN = iSBN;
            this.authorName = authorName;
            this.publication = publication;
            this.price = price;  
            availability = true;
        }

        public string Name
        {
            get { return title; }
            set { title = value; }
        }

        public string isbn
        {
            get { return ISBN; }
            set { ISBN = value; }
        }

        public string Authorname
        {
            get { return authorName; }
            set { authorName = value; }
        }

        public string Publication
        {
            get { return publication; }
            set { publication = value; }
        }

        public float Price
        {
            get { return price; } 
            set {  price = value; } 
        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }
}
