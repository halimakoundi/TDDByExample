using NUnit.Framework.Constraints;

namespace MultiCurrencyMoneyTests
{
    internal class Sum:Expression
    {
        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Augend { get; set; }
        public Money Addend { get; set; }
    }
}