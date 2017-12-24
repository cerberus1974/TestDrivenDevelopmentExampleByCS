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
            five.Times(2).Is(new Dollar(10));

            five.Times(3).Is(new Dollar(15));
        }

        [Fact]
        public void TestEquality()
        {
            new Dollar(5).Is(new Dollar(5));
            new Dollar(5).IsNot(new Dollar(6));
        }
    }
}
