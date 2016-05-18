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

            five.Times(2);

            Assert.That(five.Amount, Is.EqualTo(10));
        }
    }

    public class Dollar 
    {
        public Dollar(int amount)
        {
            this.Amount = amount;
        }

        public void Times(int multiplier)
        {
            this.Amount *= multiplier;
        }

        public int Amount { get; set; }
    }
}
