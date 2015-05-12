using System;
using System.Collections.Generic;

namespace OOP
{
    class StregsystemCLI
    {
        Stregsystem Stregsystem;
        StregsystemCommandParser Parser;

        public StregsystemCLI(Stregsystem stregsystem)
        {
            this.Stregsystem = stregsystem;
        }

        public void ParseLine()
        {
            try
            {
                this.Parser.ParseCommand(Console.ReadLine());
            }
            catch(Exception e)
            {
                DisplayGeneralError(e.Message);
            }

            ParseLine();
        }

        public void Start(StregsystemCommandParser parser)
        {
            this.Parser = parser;

            foreach (Product product in this.Stregsystem.GetActiveProducts())
            {
                Console.WriteLine(product);
            }

            ParseLine();
        }

        public void DisplayTransactionList(User user, int amount)
        {
            Console.WriteLine("\r\nTRANSACTIONS");
            Console.WriteLine("----------------------------------------------------------------");

            List<Transaction> list = this.Stregsystem.GetTransactionList(user, amount);

            if (list.Count > 0)
            {
                foreach (Transaction transaction in list)
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("No transactions was found");
            }

            Console.WriteLine("----------------------------------------------------------------");
        }

        public void DisplayUserNotFound()
        {
            Console.WriteLine("user not found");
        }

        public void DisplayProductNotFound()
        {
            Console.WriteLine("product not found");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user);
        }

        public void DisplayTooManyArgumentsError()
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("{0} bought {1}", transaction.User.Username, transaction.Product.Name);
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("{0} bought {1}x {2}", transaction.User.Username, count, transaction.Product.Name);
        }

        public void Close()
        {
            Console.Clear();
        }

        public void DisplayInsufficientCash()
        {
            Console.WriteLine("Insufficient Cash");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("\r\nERROR");
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine(errorString);

            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
