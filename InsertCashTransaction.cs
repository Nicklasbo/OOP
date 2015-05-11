using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class InsertCashTransaction : Transaction
    {
        public float Amount;

        public InsertCashTransaction(User user, float amount)
        {
            this.TransactionID = ++ID;
            this.User = user;
            this.Date = DateTime.Now;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return string.Format("{0}\tDeposit \t{1}\t{2}\t{3}", this.Date, this.TransactionID, this.User.Username, this.Amount);
        }

        public override void Execute()
        {
            this.User.Balance += Amount;
        }
    }
}
