using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Sum : IExpression
    {
        public IExpression Augend { get; }
        public IExpression Addend { get; }

        public Sum(IExpression augend, IExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            var amount = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public IExpression Plus(IExpression addend) => new Sum(this, addend);

        public IExpression Times(int multiplier) => new Sum(Augend.Times(multiplier), Addend.Times(multiplier));
    }
}
