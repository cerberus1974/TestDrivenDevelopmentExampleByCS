using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
        }

        public Franc Times(int multiplier)
        {
            return new Franc(amount * multiplier);
        }
    }
}
