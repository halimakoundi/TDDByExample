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
            var tenDollar = Money.Dollar(10);

            var five = Money.Dollar(5);
            Expression sum = five.Plus(five);
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");

            Assert.That(reduced, Is.EqualTo(tenDollar));
        }

        [Test]
        public void TestPlusReturnsSum()
        {
            Money fiveDollar = Money.Dollar(5);

            Expression result = fiveDollar.Plus(fiveDollar);
            Sum sum = (Sum) result;
            
            Assert.That(fiveDollar, Is.EqualTo(sum.Augend));
            Assert.That(fiveDollar, Is.EqualTo(sum.Addend));
        }




    }
}
