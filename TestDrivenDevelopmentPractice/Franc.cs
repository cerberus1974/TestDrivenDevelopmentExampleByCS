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

        public override string Currency() => "CHF";

        public override Money Times(int multiplier) => new Franc(amount * multiplier);
    }
}
