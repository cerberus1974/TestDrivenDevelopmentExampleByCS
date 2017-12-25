﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Money : IExpression
    {
        protected int amount;

        protected string currency;

        public string Currency => currency;

        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && Currency == money.Currency;
        }

        public Money Times(int multiplier) => new Money(amount * multiplier, currency);

        public IExpression Plus(Money addend) => new Money(amount + addend.amount, currency);

        static public Money Dollar(int amount) => new Money(amount, "USD");

        static public Money Franc(int amount) => new Money(amount, "CHF");
    }
}
