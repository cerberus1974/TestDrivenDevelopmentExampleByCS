using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            var sum = source as Sum;
            return sum.Reduce(to);
        }
    }
}
