using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    internal class RecursiveDescent
    {
        List<Variable> Variables;

        ConstraintInt ConstraintUsed;

        public RecursiveDescent(List<Variable> variablesInput, ConstraintInt constraintUsed)
        {
            Variables = variablesInput;
            ConstraintUsed = constraintUsed;
        }

        //begin by only checking the constraints that youc can fully determine

        public string Solver()
        {
            SolverHelper(new List<Variable>());

            string Result = "";

            for (int i = 0; i < Variables.Count; i++)
            {
                Result += Variables[i].Guess.ToString() + ", ";
            }

            return Result;
        }

        enum Cars
        {
            Lambo = 1,
            ToyotaCorolla = 9999999,
        };

        private bool SolverHelper(List<Variable> VariablesGuessed)
        {
            Variable VarPointer = Variables[VariablesGuessed.Count];

            VariablesGuessed.Add(VarPointer);

            for (int i = 0; i < VarPointer.Domain.Count; i++)
            {
                VarPointer.Guess = VarPointer.Domain[i];

                if (ConstraintUsed.ConstraintFinder(VariablesGuessed))
                {
                    if (VariablesGuessed.Count == Variables.Count)
                    {
                        return true;
                    }

                    if (SolverHelper(VariablesGuessed))
                    {
                        return true;
                    }
                }
            }

            VariablesGuessed.RemoveAt(VariablesGuessed.Count-1);

            return false;
        }
    }
}
