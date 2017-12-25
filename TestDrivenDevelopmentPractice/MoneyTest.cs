using System;
using Xunit;

namespace TestDrivenDevelopmentPractice
{
    public class MoneyTest
    {
        [Fact]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5);
            five.Times(2).Is(Money.Dollar(10));

            five.Times(3).Is(Money.Dollar(15));
        }

        [Fact]
        public void TestEquality()
        {
            Money.Dollar(5).Is(Money.Dollar(5));
            Money.Dollar(5).IsNot(Money.Dollar(6));
            Money.Franc(5).IsNot(Money.Dollar(5));
        }

        [Fact]
        public void TestCurrency()
        {
            "USD".Is(Money.Dollar(1).Currency);
            "CHF".Is(Money.Franc(1).Currency);
        }

        [Fact]
        public void TestSimpleAddition()
        {
            var five = Money.Dollar(5);
            var sum = five.Plus(five);
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");
            reduced.Is(Money.Dollar(10));
        }
    }
}
