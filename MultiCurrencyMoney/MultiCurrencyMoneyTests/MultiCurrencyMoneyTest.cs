using NUnit.Framework;

namespace MultiCurrencyMoneyTests
{
    [TestFixture]
    public class MultiCurrencyMoneyTest
    {
        [Test]
        public void TestMultiplication()
        {
            var five = Money.Dollar(5);
            var product = five.Times(2);

            Assert.That(product, Is.EqualTo(Money.Dollar(10)));

            product = five.Times(3);

            Assert.That(product, Is.EqualTo(Money.Dollar(15)));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(Money.Dollar(5).Equals(Money.Dollar(5)), Is.True);
            Assert.That(Money.Dollar(5).Equals(Money.Dollar(6)), Is.False);
            Assert.That(Money.Franc(5).Equals(Money.Dollar(5)), Is.False);
        }

        [Test]
        public void TestCurrency()
        {
            var currencyCode = Money.Dollar(1).GetCurrency();

            Assert.That(currencyCode, Is.EqualTo("USD"));
        }

        [Test]
        public void TestSimpleAddition()
        {
            var tenDollar   =  Money.Dollar(10);
            var sum = Money.Dollar(5).Plus(Money.Dollar(5));

            Assert.That(sum, Is.EqualTo(tenDollar));
        }
    }
}
