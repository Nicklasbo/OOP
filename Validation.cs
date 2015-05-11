using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP
{
    class Validation
    {
        public static string Username(string username)
        {
            if (!Regex.IsMatch(username, @"^[a-z0-9_]+$"))
            {
                throw new ValidationException("invalid username");
            }

            return username;
        }

        public static string Email(string email)
        {
            if (!Regex.IsMatch(email, @"^[\w\-\.]+@[\w][\w\.\-]+\.[\w\.\-]+[\w]$"))
            {
                throw new ValidationException("invalid email");
            }

            return email;
        }

        public static T Required<T>(T input)
        {
            if (input == null)
            {
                throw new ValidationException("required field cannot be null");
            }

            return input;
        }
    }
}
