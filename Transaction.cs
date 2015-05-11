using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Transaction
    {
        public static int ID = 0;

        public int TransactionID;
        public User User;
        public DateTime Date;
        public float Amount;

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2}", this.TransactionID, this.Amount, this.Date);
        }

        public virtual void Execute()
        {

        }
    }
}
