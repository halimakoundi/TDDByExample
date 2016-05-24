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
        public void TestFrancMultiplication()
        {
            var fiveFranc   = new Franc(5);

            Assert.That(new Franc(10), Is.EqualTo(fiveFranc.Times(2)));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(new Dollar(5).Equals(new Dollar(5)), Is.EqualTo(true));
            Assert.That(new Dollar(5).Equals(new Dollar(6)), Is.EqualTo(false));
            Assert.That(new Franc(5).Equals(new Franc(5)), Is.EqualTo(true));
            Assert.That(new Franc(5).Equals(new Franc(6)), Is.EqualTo(false));
        }
    }
}
