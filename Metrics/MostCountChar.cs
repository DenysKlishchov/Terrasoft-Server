using ASPControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPControl.Metrics
{
    public class MostCountChar : BaseMetrics
    {
        private Dictionary<char, int> _symbols = new Dictionary<char, int>();
        public override void Process(char symbol)
        {
            if (Char.IsSeparator(symbol) || symbol == (char)13)
                return;
            if (_symbols.ContainsKey(symbol))
                _symbols[symbol]++;
            else
                _symbols.Add(symbol, 1);
        }

        public override string Result()
        {
            var item = _symbols.OrderByDescending(c => c.Value).FirstOrDefault();
            return $"Most common symbol {item.Key}, number of occurrences {item.Value}";
        }
    }
}