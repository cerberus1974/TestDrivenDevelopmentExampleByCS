using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    interface IExpression
    {
        Money Reduce(Bank bank, string to);
    }
}
