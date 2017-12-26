using System;
using Xunit;

namespace TestDrivenDevelopmentPractice
{
    public class MoneyTest
    {
        [Fact]
        public void TestMultiplication()
        {
            var five = Money.Dollar(5);
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

        [Fact]
        public void TestPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            var result = five.Plus(five);
            var sum = (Sum)result;
            sum.Augend.Is(five);
            sum.Addend.Is(five);
        }

        [Fact]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            result.Is(Money.Dollar(7));
        }

        [Fact]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(1), "USD");
            result.Is(Money.Dollar(1));
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
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
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            result.Is(Money.Dollar(10));
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            var result = bank.Reduce(sum, "USD");
            result.Is(Money.Dollar(15));
        }
    }
}
