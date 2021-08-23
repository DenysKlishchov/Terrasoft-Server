using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPControl.Abstract
{
    public abstract class BaseMetrics
    {
        public abstract void Process(char symbol);
        public abstract string Result();
    }
}