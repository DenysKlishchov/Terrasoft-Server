using ASPControl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPControl.Class
{
    public class TextAnalysis
    {
        private ITextReader _reader;
        private List<BaseMetrics> _metrics;

        public IReadOnlyList<BaseMetrics> Metrics => _metrics;

        public TextAnalysis(ITextReader reader)
        {
            _reader = reader;
            _metrics = new List<BaseMetrics>();
        }

        public void AddMetrics(BaseMetrics metrics)
        {
            _reader.CharRead += metrics.Process;
            _metrics.Add(metrics);
        }

        public void Analyz()
        {
            _reader.Read();
        }
    }
}