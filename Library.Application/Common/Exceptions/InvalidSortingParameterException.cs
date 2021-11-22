using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Common.Exceptions
{
    public class InvalidSortingParameterException : Exception
    {
        public InvalidSortingParameterException(object key)
           : base($"Sorting parameter '{key}' is invalid.") { }
    }
}
