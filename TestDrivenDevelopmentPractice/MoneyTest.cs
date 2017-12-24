using System;
using Xunit;

namespace TestDrivenDevelopmentPractice
{
    public class MoneyTest
    {
        [Fact]
        public void TestMultiplication()
        {
            var five = new Dollar(5);
            var product = five.Times(2);
            product.amount.Is(10);

            product = five.Times(3);
            product.amount.Is(15);
        }

        [Fact]
        public void TestEquality()
        {
            new Dollar(5).Is(new Dollar(5));
            new Dollar(5).IsNot(new Dollar(6));
        }
    }
}
