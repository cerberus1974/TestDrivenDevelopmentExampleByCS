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
            Money.Franc(5).Is(Money.Franc(5));
            Money.Franc(5).IsNot(Money.Franc(6));
            Money.Franc(5).IsNot(Money.Dollar(5));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            Money five = Money.Franc(5);
            five.Times(2).Is(Money.Franc(10));

            five.Times(3).Is(Money.Franc(15));
        }

        [Fact]
        public void TestCurrency()
        {
            "USD".Is(Money.Dollar(1).Currency());
            "CHF".Is(Money.Franc(1).Currency());
        }
    }
}
