using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Money
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

        static public Money Dollar(int amount) => new Dollar(amount, "USD");

        static public Money Franc(int amount) => new Franc(amount, "CHF");
    }
}
