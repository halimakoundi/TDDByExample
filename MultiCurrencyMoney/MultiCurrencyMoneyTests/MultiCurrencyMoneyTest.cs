using NUnit.Framework;
using NUnit.Framework.Constraints;

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
            Sum sum = (Sum)result;

            Assert.That(fiveDollar, Is.EqualTo(sum.Augend));
            Assert.That(fiveDollar, Is.EqualTo(sum.Addend));
        }

        [Test]
        public void TestReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();

            var result = bank.Reduce(sum, "USD");

            Assert.That(Money.Dollar(7), Is.EqualTo(result));
        }

        [Test]
        public void TestReduceMoney()
        {
            var bank = new Bank();

            var result = bank.Reduce(Money.Dollar(1), "USD");

            Assert.That(Money.Dollar(1), Is.EqualTo(result));
        }

        [Test]
        public void TestReduceMoneyWithDifferentCurrencies()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(Money.Franc(2), "USD");
            Assert.That(Money.Dollar(1), Is.EqualTo(result));
        }

        [Test]
        public void TestidentityRate()
        {
            Assert.That(1,Is.EqualTo(new Bank().Rate("USD","USD")));
        }

        [Test]
        public void TestMixedAddition()
        {
            var bank    =   new Bank();
            bank.AddRate("CHF", "USD",2);
            Expression fiveDollar=Money.Dollar(5);
            Expression tenFrancs   =Money.Franc(10);

            var result  =   bank.Reduce(fiveDollar.Plus(tenFrancs), "USD");

            Assert.That(Money.Dollar(10), Is.EqualTo(result));
        }

        [Test]
        public void TestSumPlusMoney()
        {
            var bank=new Bank();
            bank.AddRate("CHF","USD",2);
            var fiveDollar=Money.Dollar(5);
            var tenFrancs=Money.Franc(10);
            var sum =new Sum(fiveDollar, tenFrancs).Plus(fiveDollar);

            var result  = bank.Reduce(sum, "USD");

            Assert.That(Money.Dollar(15),Is.EqualTo(result));
        }

        [Test]
        public void TestSumTimes()
        {
            var bank=new Bank();
            bank.AddRate("CHF","USD",2);
            var fiveDollars=Money.Dollar(5);
            var tenFrancs   =Money.Franc(10);
            var sum=new Sum(fiveDollars,tenFrancs).Times(2);
            var resut= bank.Reduce(sum,"USD");
            Assert.That(Money.Dollar(20),Is.EqualTo(resut));
        }

    }
}
