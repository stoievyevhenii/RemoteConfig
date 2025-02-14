using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Core.Exceptions
{
    public class DublicateRecordException : Exception
    {
        public DublicateRecordException(string message) : base(message)
        {
        }
    }
}