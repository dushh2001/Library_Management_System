using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.InteropServices;
using static MongoDB.Bson.Serialization.BsonDeserializationContext;


namespace libraryproject
{
    public class Program
    {
        [DllImport("Kernel32.dll")]

        static extern bool FreeConsole();

        [STAThread]
        public static void Main(string[] args)
        {
            runApplication();
        }

        //run application
        static void runApplication()
        {
            bool running = true;
            do
            {
                try
                {
                    welcomeMessage();
                    Console.WriteLine("******************************");
                    Console.WriteLine();
                    Console.WriteLine("Choose your option to run");
                    Console.WriteLine();
                    Console.WriteLine("\t1. Run the application with GUI");
                    Console.WriteLine();
                    Console.WriteLine("\t2. Run the application with Console");
                    Console.WriteLine();
                    Console.WriteLine("\t3. Exit");
                    Console.WriteLine();
                    Console.Write("Enter your choice : ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1: // Run the application with GUI
                            FreeConsole();
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new LMS());
                            running = false;
                            break;
                        case 2:// Run the application with Console
                            Console.WriteLine("Running the application with Console");
                            Console.Clear();
                            LibrarianLoginFace();
                            break;
                        case 3:// Exit
                            Console.WriteLine("Exiting the application");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            } while (running);

        }

        //welcome message
        static void welcomeMessage()
        {
            Console.WriteLine("Welcome to the LMS");
        }

        ////////// Librarian
        static void LibrarianLoginFace()
        {
            bool running = true;
            do
            {

                try
                {
                    int choice = 0;
                    Console.WriteLine();
                    Console.WriteLine("Choose your option to run");
                    Console.WriteLine();
                    Console.WriteLine("\t1. Librarian Login");
                    Console.WriteLine();
                    Console.WriteLine("\t2. Member Login");
                    Console.WriteLine();
          
                    Console.WriteLine("\t3. Back");
                    Console.WriteLine();
                    Console.Write("Enter your choice : ");
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1: // Librarian Login
                            Console.Clear();
                            LibrarianLoginForm();
                            //running = false;
                            break;
                        case 2:// Member Login
                            Console.WriteLine("Running the application with Console");
                            break;
                        case 3: // Transaction
                            Console.WriteLine("Exiting the application");
                            Console.Clear();
                            //LibrarianMainFace();
                            running = false;
                            break;
                        case 4:// back
                            Console.Clear();
                            Application.Exit();
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            } while (running);

        }

        //Librarian Login
        static void LibrarianLoginForm()
        {
            string userID;
            string password;

            Console.WriteLine("Librarian Login");
            Console.WriteLine();
            Console.Write("\tEnter your User ID : ");
            userID = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\tEnter your Password : ");
            password = Console.ReadLine();
            Console.WriteLine();

            var client = new MongoClient().GetDatabase("Library");
            var librarian = client.GetCollection<Librarian>("Librarians").Find(x => x.Id == userID).FirstOrDefault();

            if (librarian != null)
            {
                if (librarian.login(userID, password))
                {
                    Console.WriteLine("Login Successful!");
                    Console.WriteLine();
                    Console.Clear();
                    LibrarianMainFace(librarian as Librarian);
                }
            }
            else
            {
                Console.WriteLine("Invalid User ID or Password");
                Console.WriteLine();
                Console.Clear();
                LibrarianLoginForm();
            }


        }

        //Librarian Dashboard
        static void LibrarianMainFace(Librarian librarian)
        {

            bool running = true;
            do
            {

                try
                {
                    int choice = 0;
                    Console.WriteLine();
                    Console.WriteLine("Choose your option to run");
                    Console.WriteLine();
                    Console.WriteLine("\t1. Add Book");
                    Console.WriteLine();
                    Console.WriteLine("\t2. Remove Book");
                    Console.WriteLine();
                    Console.WriteLine("\t3. Add Member");
                    Console.WriteLine();
                    Console.WriteLine("\t4. Remove Member");
                    Console.WriteLine();
                    Console.WriteLine("\t5. Back");
                    Console.WriteLine();
                    Console.Write("Enter your choice : ");
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1: // Add Book
                            Console.Clear();
                            LibrarianAddBookFace(librarian);
                            //running = false;
                            break;
                        case 2:// Remove Book
                            Console.WriteLine("Running the application with Console");
                            Console.Clear();
                            LibraryRemoveBookFace(librarian);
                            break;
                        case 3: // Add Member
                            Console.WriteLine("Exiting the application");
                            Console.Clear();
                            //LibrarianMainFace(librarian);
                            //running = false;
                            continue;
                        case 4:// Remove Member
                            Console.Clear();
                            Application.Exit();
                            running = false;
                            break;
                        case 5:// back
                            Console.Clear();
                            LibrarianLoginFace();
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            } while (running);

        }



        //Librarian Add Book

        static void LibrarianAddBookFace(Librarian  librarian)
        {
            try
            {
                string isbn;
                string name;
                string authorname;
                string publication;
                float price;

                Console.WriteLine("Enter the details to add a new book");
                Console.WriteLine();
                Console.Write("\tEnter the ISBN : ");
                isbn = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\tEnter the Name : ");
                name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\tEnter the Author Name : ");
                authorname = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\tEnter the Publication : ");
                publication = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\tEnter the Price : ");
                price = float.Parse(Console.ReadLine());
               
                
                // Add book to the library
                //Librarian librarian = new Librarian("name", "id", "password", "email", "contact");
                // Add book to the database
                librarian.addBook(isbn, name, authorname, publication, price);

                Console.WriteLine();
                Console.WriteLine("Book added successfully");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" Press any key to go back");
                Console.ReadKey();
                Console.Clear();

            }
             catch (FormatException e)
             {
                 Console.WriteLine("Error: " + e.Message);
             }
            
        }

        //Librarian Remove Book
        static void LibraryRemoveBookFace(Librarian librarian)
        {
            try
            {
                string isbn;
                string name;
                
                Console.WriteLine("Enter the details to remove a new book");
                Console.WriteLine();
                Console.Write("\tEnter the ISBN : ");
                isbn = Console.ReadLine();
                Console.WriteLine();
                Console.Write("\tEnter the Name : ");
                name = Console.ReadLine();
                Console.WriteLine();
                Book book = Database.getBookByISBN(isbn);

                if (book != null)
                {
                    librarian.removeBook(book);

                    Console.WriteLine();
                    Console.WriteLine("Book removed successfully");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Book not found!");

                }

                Console.WriteLine();
                Console.WriteLine(" Press any key to go back");
                Console.ReadKey();
                Console.Clear();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }


        //Librarian Add Member
        static void LibrarianAddMemberFace()
        {
            
        }

        //Librarian Remove Member
        static void LibraryRemoveMemberFace()
        {

        }

        ///////Member
        static void MemberLoginFace()
        {

        }

        // Member Dashboard
        static void MemberMainFace()
        {

        }

        //Member Borrow Book
        static void MemberBorrowBookFace()
        {

        }

        //Member Return Book
        static void MemberReturnBookFace()
        {

        }

        //Member View Book Collection
        static void MemberViewBookCollection()
        {

        }

        ///////////// Transactions
        static void TransactionsFace()
        {

        }



























    }
}
