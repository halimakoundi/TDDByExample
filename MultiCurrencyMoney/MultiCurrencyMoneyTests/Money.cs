namespace MultiCurrencyMoneyTests
{
    public class Money : Expression
    {
        public int Amount { get; set; }
        protected string Currency { get; set; }

        public Money(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public string GetCurrency()
        {
            return Currency;
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Expression Plus(Money addend)
        {
            return new Sum(this,addend);
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;

            return this.Amount == money.Amount && Currency.Equals(money.Currency);
        }

        public Money Reduce(string to)
        {
            return this;
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}
