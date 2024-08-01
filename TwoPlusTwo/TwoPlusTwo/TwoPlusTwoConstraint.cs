using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    internal class TwoPlusTwoConstraint : ConstraintInt
    {

        public TwoPlusTwoConstraint()
        {
        }
        //Constraint finder
        //loop through all constraints, 
        //for each one look at all the used variables, and see if you have picked a value for this variable


        public override bool ConstraintFinder(List<Variable> VarInput)
        {
            bool checker = true ;

            if (VarInput.Count >= 3)// OR Layer
            {
                checker = checker && ORLayer(VarInput);

            }
             if (VarInput.Count >= 6)
            {
                checker = checker && WULayer(VarInput);
            }
             if (VarInput.Count >= 8)
            {
                checker = checker && TOLayer(VarInput);
            }
             if (VarInput.Count >= 9)
            {
                checker = checker && FLayer(VarInput);
            }



            // O != R
            if (VarInput.Count >= 2)
            {
                if (VarInput[0].Guess.Equals(VarInput[1].Guess))
                {
                    return false;
                }
            }
            //o!= W
            if (VarInput.Count >= 4)
            {
                if (VarInput[0].Guess.Equals(VarInput[3].Guess))
                {
                    return false;
                }
            }
            //o != U
            if (VarInput.Count >= 5)
            {
                if (VarInput[0].Guess.Equals(VarInput[4].Guess))
                {
                    return false;
                }
            }
            // o != T
            if (VarInput.Count >= 7)
            {
                if (VarInput[0].Guess.Equals(VarInput[6].Guess))
                {
                    return false;
                }
            }
            // o != F
            if (VarInput.Count >= 9)
            {
                if (VarInput[0].Guess.Equals(VarInput[8].Guess))
                {
                    return false;
                }
            }


            //R!= W
            if (VarInput.Count >= 4)
            {
                if (VarInput[1].Guess.Equals(VarInput[3].Guess))
                {
                    return false;
                }
            }
            //R != U
            if (VarInput.Count >= 5)
            {
                if (VarInput[1].Guess.Equals(VarInput[4].Guess))
                {
                    return false;
                }
            }
            // R != T
            if (VarInput.Count >= 7)
            {
                if (VarInput[1].Guess.Equals(VarInput[6].Guess))
                {
                    return false;
                }
            }
            // R != F
            if (VarInput.Count >= 9)
            {
                if (VarInput[1].Guess.Equals(VarInput[8].Guess))
                {
                    return false;
                }
            }




            //W != U
            if (VarInput.Count >= 5)
            {
                if (VarInput[3].Guess.Equals(VarInput[4].Guess))
                {
                    return false;
                }
            }
            // W!= T
            if (VarInput.Count >= 7)
            {
                if (VarInput[3].Guess.Equals(VarInput[6].Guess))
                {
                    return false;
                }
            }
            // W != F
            if (VarInput.Count >= 9)
            {
                if (VarInput[3].Guess.Equals(VarInput[8].Guess))
                {
                    return false;
                }
            }




            // U!= T
            if (VarInput.Count >= 7)
            {
                if (VarInput[4].Guess.Equals(VarInput[6].Guess))
                {
                    return false;
                }
            }
            // U != F
            if (VarInput.Count >= 9)
            {
                if (VarInput[4].Guess.Equals(VarInput[8].Guess))
                {
                    return false;
                }
            }



            // T!= F
            if (VarInput.Count >= 9)
            {
                if (VarInput[6].Guess.Equals(VarInput[8].Guess))
                {
                    return false;
                }
            }

            if(VarInput.Count >= 9)
            {
                if (VarInput[8].Guess == 0)
                {
                    return false;
                }
            }

            return checker;
        }

        //O,R,C1,W,U,C2,T,C3,F
        //0,1, 2,3,4, 5,6, 7,8


        //0,1,2
        public bool ORLayer(List<Variable> Input) => Input[0].Guess * 2 == Input[1].Guess + Input[2].Guess * 10;


        //0, 1, 2, 3, 4, 5
        public bool WULayer(List<Variable> Input) => Input[3].Guess * 2 + Input[2].Guess == Input[4].Guess + Input[5].Guess * 10;


        //0,1, 2,3, 4, 5, 6, 7
        public bool TOLayer(List<Variable> Input) => Input[6].Guess * 2 + Input[5].Guess == Input[0].Guess + Input[7].Guess * 10;


        //0,2,3, 4, 5, 6, 7, 8
        public bool FLayer(List<Variable> Input) => Input[7].Guess == Input[8].Guess;

        



        //take in GUESSES FOR EACH variables, check if their compatible
        //take in the guess, and plug them into the function and return true and false

        // any # of variables, int[] of guesses, 

        public bool ConstraintCheck(Variable[] Input, Func<Variable[], bool> Function)
        {

            return Function(Input);

        }

    }
}
