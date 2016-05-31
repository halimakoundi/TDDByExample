namespace MultiCurrencyMoneyTests
{
    public interface Expression
    {
        Money Reduce(string to);
    }
}