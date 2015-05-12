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

        public void LogTransaction() {
            using (StreamWriter w = File.AppendText("../../log.txt"))
            {
                w.WriteLine(this);
            }
        }

        public virtual void Execute()
        {

        }
    }
}
