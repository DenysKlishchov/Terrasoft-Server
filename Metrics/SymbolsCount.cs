using ASPControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPControl.Metrics
{
    public class SymbolsCount : BaseMetrics
    {
        private int _result = 0;

        public override void Process(char symbol)
        {
            if (Char.IsSeparator(symbol) || symbol == (char)13)
                return;

            _result++;
        }

        public override string Result() => $"Count of symbols: {_result}";
    }
}