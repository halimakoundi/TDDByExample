using System;
using NUnit.Framework;

namespace MultiCurrencyMoneyTests
{
    [TestFixture]
    public class MultiCurrencyMoneyTest
    {
        [Test]
        public void TestMultiplication()
        {
            var five = new Dollar(5);

            var product = five.Times(2);

            Assert.That(product, Is.EqualTo(new Dollar(10)));

            product = five.Times(3);

            Assert.That(product, Is.EqualTo(new Dollar(15)));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(new Dollar(5).Equals(new Dollar(5)), Is.EqualTo(true));
            Assert.That(new Dollar(5).Equals(new Dollar(6)), Is.EqualTo(false));
        }
    }

    public class Dollar
    {
        public Dollar(int amount)
        {
            this.Amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(this.Amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            var dollar = (Dollar) obj;

            return this.Amount == dollar.Amount;
        }

        private int Amount { get; set; }
    }
}
