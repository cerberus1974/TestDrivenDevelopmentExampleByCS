using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            return Money.Dollar(10);
        }
    }
}
