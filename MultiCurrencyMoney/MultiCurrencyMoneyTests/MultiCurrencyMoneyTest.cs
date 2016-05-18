using NUnit.Framework;

namespace MultiCurrencyMoneyTests
{
    [TestFixture]
    public class    MultiCurrencyMoneyTest
    {
        [Test]
        public void TestMultiplication()
        {
            var five= new Dollar(5);

            var product = five.Times(2);

            Assert.That(product.Amount, Is.EqualTo(10));

            product = five.Times(3);

            Assert.That(product.Amount, Is.EqualTo(15));
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

        public int Amount { get; set; }
    }
}
