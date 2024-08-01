using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    public class PassableConstraint
    {
        public int LengthCheck;
        public Func<List<Variable>, bool> Condition;

        public PassableConstraint(int lengthCheck, Func<List<Variable>, bool> gondition, List<Variable> VarsUsed = null)
        {
            LengthCheck = lengthCheck;
            Condition = gondition;

        }
    }
}
