using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    public abstract class ConstraintInt
    {
        public List<PassableConstraint> Constraints = new List<PassableConstraint>();

        public Dictionary<PassableConstraint, List<Variable>> ArcAssociation = new();
            //if the passable constraint knows the list of variables it is asociated with, then the arc can check the list of variables



        //Notes:
        //virtual: can override, but this is the default
        //abstract: has to be overrided

        public virtual bool ConstraintFinder(List<Variable> VarInput)
        {
            bool checker = true;

            for (int i = 0; i < Constraints.Count; i++)
            {
                if (Constraints[i].LengthCheck <= VarInput.Count)
                {
                    checker = checker && Constraints[i].Condition(VarInput);
                }

            }

            return checker;
        }
    }
}

