namespace MultiCurrencyMoneyTests
{
    public class Franc : Money
    {
        public Franc(int amount)
        {
            this.Amount = amount;
        }

        public override Money Times(int multiplier)
        {
            return new Franc(this.Amount * multiplier);
        }

        public override string Currency()
        {
            return "CHF";
        }
    }
}