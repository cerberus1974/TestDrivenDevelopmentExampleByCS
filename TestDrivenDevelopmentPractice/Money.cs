using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentPractice
{
    class Money : IExpression
    {
        protected string currency;

        public int Amount { get; }

        public string Currency => currency;

        public Money(int amount, string currency)
        {
            Amount = amount;
            this.currency = currency;
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && Currency == money.Currency;
        }

        public IExpression Times(int multiplier) => new Money(Amount * multiplier, currency);

        public IExpression Plus(IExpression addend) => new Sum(this, addend);

        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(currency, to);
            return new Money(Amount / rate, to);
        }

        static public Money Dollar(int amount) => new Money(amount, "USD");

        static public Money Franc(int amount) => new Money(amount, "CHF");
    }
}
