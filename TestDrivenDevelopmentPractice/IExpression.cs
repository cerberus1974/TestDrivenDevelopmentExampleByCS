using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    interface IExpression
    {
        IExpression Plus(IExpression addend);
        IExpression Times(int multiplier);
        Money Reduce(Bank bank, string to);
    }
}
