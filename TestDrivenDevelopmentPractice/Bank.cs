using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Bank
    {
        private Dictionary<Pair, int> rates = new Dictionary<Pair, int>();

        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from == to) return 1;
            return rates.GetValueOrDefault(new Pair(from, to));
        }
    }
}
