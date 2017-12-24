﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    abstract class Money
    {
        protected int amount;

        protected string currency;

        public abstract Money Times(int amount);

        public string Currency => currency;

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && GetType() == money.GetType();
        }

        static public Money Dollar(int amount) => new Dollar(amount);

        static public Money Franc(int amount) => new Franc(amount);
    }
}
