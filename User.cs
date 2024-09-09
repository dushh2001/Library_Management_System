using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryproject
{
    public class User
    {
        private string id;
        private string password;
        private string name;
        private string email;
        private string contact;

        public User(string name, string id, string password, string email, string contact)
        {
            this.name = name;
            this.id = id;
            this.password = password;
            this.email = email;
            this.contact = contact;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public bool login(string id, string password)
        {
            if (this.id == id && this.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
