using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transaction
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    string id;
    string bookISBN;
    string memberID;
    string memberName;
    string transactionType;
    DateTime date;

    public Transaction(string bookISBN, string memberID, string memberName, string transactionType,DateTime date)
    {
        this.bookISBN = bookISBN;
        this.memberID = memberID;
        this.memberName = memberName;
        this.date = date;
        this.transactionType = transactionType;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string BookISBN
    {
        get { return bookISBN; }
        set { bookISBN = value; }
    }
    public string MemberID
    {
        get { return memberID; }
        set { memberID = value; }
    }
    public string MemberName
    {
        get { return memberName; }
        set { memberName = value; }
    }
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    public string TransactionType
    {
        get { return transactionType; }
        set { transactionType = value; }
    }
}