using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency)
        {
        }

        public override Money Times(int multiplier) => Money.Dollar(amount * multiplier);
    }
}
