using System;
using Xunit;

namespace TestDrivenDevelopmentPractice
{
    public class MoneyTest
    {
        IExpression fiveBucks;
        IExpression tenFrancs;
        Bank bank;

        public MoneyTest()
        {
            fiveBucks = Money.Dollar(5);
            tenFrancs = Money.Franc(10);
            bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
        }

        [Fact]
        public void TestMultiplication()
        {
            fiveBucks.Times(2).Is(Money.Dollar(10));
            fiveBucks.Times(3).Is(Money.Dollar(15));
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
            var sum = fiveBucks.Plus(fiveBucks);
            var reduced = bank.Reduce(sum, "USD");
            reduced.Is(Money.Dollar(10));
        }

        [Fact]
        public void TestPlusReturnsSum()
        {
            var result = fiveBucks.Plus(fiveBucks);
            var sum = (Sum)result;
            sum.Augend.Is(fiveBucks);
            sum.Addend.Is(fiveBucks);
        }

        [Fact]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var result = bank.Reduce(sum, "USD");
            result.Is(Money.Dollar(7));
        }

        [Fact]
        public void TestReduceMoney()
        {
            var result = bank.Reduce(Money.Dollar(1), "USD");
            result.Is(Money.Dollar(1));
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var result = bank.Reduce(Money.Franc(2), "USD");
            result.Is(Money.Dollar(1));
        }

        [Fact]
        public void TestIdentityRate()
        {
            new Bank().Rate("USD", "USD").Is(1);
        }

        [Fact]
        public void TestMixedAddition()
        {
            var result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            result.Is(Money.Dollar(10));
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            var sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            var result = bank.Reduce(sum, "USD");
            result.Is(Money.Dollar(15));
        }

        [Fact]
        public void TestSumTimes()
        {
            var sum = new Sum(fiveBucks, tenFrancs).Times(2);
            var result = bank.Reduce(sum, "USD");
            result.Is(Money.Dollar(20));
        }
    }
}
