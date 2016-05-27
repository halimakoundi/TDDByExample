namespace MultiCurrencyMoneyTests
{
    public class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency) { }

        public  Money Times(int multiplier)
        {
            return new Money(this.Amount * multiplier, Currency);
        }
    }
}