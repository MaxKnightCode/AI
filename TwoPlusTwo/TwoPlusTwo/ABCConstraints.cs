using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    public class ABCConstraints : ConstraintInt
    {

        public ABCConstraints()
        {


            Constraints.Add(new PassableConstraint(2, AtoB));
            Constraints.Add(new PassableConstraint(3, AtoC));

            Constraints.Add(new PassableConstraint(3, BtoC));
            Constraints.Add(new PassableConstraint(2, BtoA));

            Constraints.Add(new PassableConstraint(3, CtoA));
            Constraints.Add(new PassableConstraint(3, CtoB));
        }

        //A = 0
        //B = 1
        //C = 2


        public bool AtoB(List<Variable> VarInp) => VarInp[0].Guess != VarInp[1].Guess;
        public bool AtoC(List<Variable> VarInp) => VarInp[0].Guess > VarInp[2].Guess;

        public bool BtoC(List<Variable> VarInp) => VarInp[1].Guess < VarInp[2].Guess;
        public bool BtoA(List<Variable> VarInp) => VarInp[1].Guess != VarInp[0].Guess;

        public bool CtoA(List<Variable> VarInp) => VarInp[2].Guess < VarInp[0].Guess;
        public bool CtoB(List<Variable> VarInp) => VarInp[2].Guess > VarInp[1].Guess;

    }
}
