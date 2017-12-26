using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    interface IExpression
    {
        IExpression Plus(IExpression addend);
        Money Reduce(Bank bank, string to);
    }
}
