using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Stregsystem
    {
        List<User> users = new List<User>() {
            new User("Rasmus", "Nørskov", "rnarsk14", "rnarsk14@student.aau.dk"),
            new User("Thomas", "Bøgholm", "boegholm", "boegholm@cs.aau.dk"),
            new User("Kurt", "Nørmark", "normark", "normark@cs.aau.dk")
        };

        List<Product> products = Product.ReadFile();

        List<Transaction> transactions = new List<Transaction>();

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product);

            ExecuteTransaction(transaction);

            return transaction;
        }

        public InsertCashTransaction AddCreditsToAccount(User user, float amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);

            ExecuteTransaction(transaction);

            return transaction;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();

            transactions.Add(transaction);
        }

        public Product GetProduct(int productID)
        {
            foreach (Product product in products)
            {
                if (product.ProductID.Equals(productID))
                    return product;
            }

            throw new ProductNotFoundException();
        }

        public User GetUser(string username)
        {
            foreach (User user in users)
            {
                if (user.Username.Equals(username))
                    return user;
            }

            throw new UserNotFoundException("User: " + username + " was not found");
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
