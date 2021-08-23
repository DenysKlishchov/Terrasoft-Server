using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPControl.Abstract
{
    public interface ITextReader
    {
        event Action<char> CharRead;
        void Read();
    }
}
