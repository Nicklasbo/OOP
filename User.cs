using System;

namespace OOP
{
    class User : IComparable<User>
    {
        static int ID = 0;

        public int UserID;
        public string Firstname;
        public string Lastname;
        public string Username;
        public string Email;
        public float Balance = 0;

        public User(string firstname, string lastname, string username, string email)
        {
            this.UserID = ++ID;
            this.Firstname = Validation.Required(firstname);
            this.Lastname = Validation.Required(lastname);
            this.Username = Validation.Username(username);
            this.Email = Validation.Email(email);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}) kr. {3,5:f2}", this.Firstname, this.Lastname, this.Email, this.Balance);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
                return false;

            return this.UserID.Equals(((User)obj).UserID);
        }

        public override int GetHashCode()
        {
            return this.UserID.GetHashCode();
        }

        public int CompareTo(User obj)
        {
            return UserID.CompareTo(obj.UserID);
        }
    }
}
