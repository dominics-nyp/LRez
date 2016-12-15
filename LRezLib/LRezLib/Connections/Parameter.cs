using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Connections
{
    class Parameter
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }

        public Parameter(string parameterName, object value)
        {
            this.ParameterName = parameterName;
            this.Value = value;
        }
    }
}
