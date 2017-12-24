using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
            currency = "USD";
        }

        public override Money Times(int multiplier) => new Dollar(amount * multiplier);
    }
}
