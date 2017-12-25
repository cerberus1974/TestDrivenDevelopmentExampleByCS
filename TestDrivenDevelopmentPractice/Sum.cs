using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Sum : IExpression
    {
        public Money Augend { get; }
        public Money Addend { get; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string to)
        {
            var amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
    }
}
