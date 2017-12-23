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
            five.Times(2);
            five.amount.Is(10);
        }
    }
}
