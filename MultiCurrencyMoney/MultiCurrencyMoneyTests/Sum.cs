using NUnit.Framework.Constraints;

namespace MultiCurrencyMoneyTests
{
    internal class Sum:Expression
    {
        public Sum(Expression augend, Expression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Expression Augend { get; set; }
        public Expression  Addend { get; set; }

        public Money Reduce(Bank bank,string to)
        {
            var amount = Augend.Reduce(bank,to).Amount + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public Expression Plus(Expression addend)
        {
            return null;
        }
    }
}