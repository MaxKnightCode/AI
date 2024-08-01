using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    internal class VariableWrapper<T> where T : IComparable<T>
    {
        Variable ThisVar;
        Variable PreviousVar;
        
        public VariableWrapper(Variable input, Variable preiovus = null)
        {
            ThisVar = input;
            PreviousVar = preiovus;
        }



    }
}
