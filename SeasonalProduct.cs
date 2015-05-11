using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate;
        public DateTime SeasonEndDate;

        public SeasonalProduct(string name, float price, DateTime seasonStartDate, DateTime seasonEndDate, bool active = true, bool canBeBoughtOnCredit = false)
            : base(name, price, active, canBeBoughtOnCredit)
        {
            this.SeasonStartDate = seasonStartDate;
            this.SeasonEndDate = seasonEndDate;
        }
    }
}
