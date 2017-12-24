using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Money
    {
        protected int amount;


        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && GetType() == money.GetType();
        }
    }
}
