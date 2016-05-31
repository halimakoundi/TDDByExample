using System.Collections;

namespace MultiCurrencyMoneyTests
{
    public class Bank
    {
        private Hashtable _rates = new Hashtable();

        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            _rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;
            return (int)_rates[new Pair(from, to)];
        }
    }
}