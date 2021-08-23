using ASPControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPControl.Metrics
{
    public class ExclamationSentences : BaseMetrics
    {
        private int _result = 0;
        private List<char> _previous = new List<char>();
        public override void Process(char symbol)
        {
            if (Char.IsSeparator(symbol) || symbol == (char)13)
                return;

            _previous?.Add(symbol);

            if (_previous.Count >= 2)
            {
                if (symbol == '!' && symbol != _previous[_previous.Count - 2])
                {
                    _result++;
                }
            }
        }

        public override string Result() => $"Count of exclamation sentences {_result}";
    }
}