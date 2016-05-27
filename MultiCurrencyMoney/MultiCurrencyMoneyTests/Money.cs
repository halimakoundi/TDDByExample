namespace MultiCurrencyMoneyTests
{
    public abstract class Money
    {
        protected int Amount { get; set; }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }

        public abstract Money Times(int multiplier);

        public override bool Equals(object obj)
        {
            var money = (Money)obj;

            return this.Amount == money.Amount && GetType() == obj.GetType();
        }

        public abstract string Currency();
    }
}
