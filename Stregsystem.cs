using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Stregsystem
    {
        public static List<User> users = new List<User>() {
            new User("Rasmus", "Nørskov", "rnarsk14", "rnarsk14@student.aau.dk"),
            new User("Thomas", "Bøgholm", "boegholm", "boegholm@cs.aau.dk"),
            new User("Kurt", "Nørmark", "normark", "normark@cs.aau.dk")
        };

        public static List<Product> products = Product.ReadFile();

        public static List<Transaction> transactions = new List<Transaction>() {
            new InsertCashTransaction(users[0], 60),
            new BuyTransaction(users[0], products[0], 60)
        };

        public Stregsystem()
        {
            //
        }

        public void BuyProduct(User user, Product product)
        {
            ExecuteTransaction(new BuyTransaction(user, product, product.Price));
        }

        public void AddCreditsToAccount(User user, float amount)
        {
            ExecuteTransaction(new InsertCashTransaction(user, amount));
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                transaction.Execute();

                transactions.Add(transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Product GetProduct(int productID)
        {
            foreach (Product product in products)
            {
                if (product.ProductID.Equals(productID))
                    return product;
            }

            return null;
        }

        public static User GetUser(string username)
        {
            foreach (User user in users)
            {
                if (user.Username.Equals(username))
                    return user;
            }

            return null;
        }

        public List<Transaction> GetTransactionList(User user, int amount)
        {
            List<Transaction> list = new List<Transaction>();

            int count = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.User.Equals(user) && count <= amount)
                {
                    list.Add(transaction);

                    count++;
                }
            }

            return list;
        }

        public List<Product> GetActiveProducts()
        {
            List<Product> list = new List<Product>();

            foreach (Product product in products)
            {
                if (product.Active)
                {
                    list.Add(product);
                }
            }

            return list;
        }
    }
}
