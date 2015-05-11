using System;

namespace OOP
{
    class BuyTransaction : Transaction
    {
        public Product Product;

        public BuyTransaction(User user, Product product)
        {
            this.TransactionID = ++ID;
            this.User = Validation.Required(user);
            this.Product = product;
            this.Date = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("{0}\tPurchase\t{1}\t{2}\t{3}\t{4}", this.Date, this.TransactionID, this.User.Username, this.Product.Name, this.Product.Price);
        }

        public override void Execute()
        {
            if (this.User.Balance - this.Product.Price < 0 && !this.Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException("insufficient credits");
            }

            this.User.Balance -= this.Product.Price;
        }
    }
}
