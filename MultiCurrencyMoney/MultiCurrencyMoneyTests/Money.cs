namespace MultiCurrencyMoneyTests
{
    public abstract class Money
    {
        protected int Amount { get; set; }
        protected string Currency { get; set; }

        protected Money(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public abstract Money Times(int multiplier);

        public override bool Equals(object obj)
        {
            var money = (Money)obj;

            return this.Amount == money.Amount && GetType() == obj.GetType();
        }

        public string GetCurrency()
        {
            return Currency;
        }
    }
}
