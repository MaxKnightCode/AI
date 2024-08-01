using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    public class GraphColoringConstraint : ConstraintInt
    {
        //List<PassableConstraint> Constraints = new List<PassableConstraint>();

        

        public GraphColoringConstraint()
        {
            //constraints!!

            Constraints.Add(new PassableConstraint(2, A1andA2));
            Constraints.Add(new PassableConstraint(4, A1andB1));

            Constraints.Add(new PassableConstraint(2, A2andA1));
            Constraints.Add(new PassableConstraint(3, A2andA3));
            Constraints.Add(new PassableConstraint(4, A2andB1));
            Constraints.Add(new PassableConstraint(5, A2andB2));

            Constraints.Add(new PassableConstraint(3, A3andA2));
            Constraints.Add(new PassableConstraint(5, A3andB2));
            Constraints.Add(new PassableConstraint(6, A3andB3));

            Constraints.Add(new PassableConstraint(4, B1andA1));
            Constraints.Add(new PassableConstraint(4, B1andA2));
            Constraints.Add(new PassableConstraint(5, B1andB2));
            Constraints.Add(new PassableConstraint(7, B1andC1));

            Constraints.Add(new PassableConstraint(5, B2andA2));
            Constraints.Add(new PassableConstraint(5, B2andA3));
            Constraints.Add(new PassableConstraint(5, B2andB1));
            Constraints.Add(new PassableConstraint(6, B2andB3));
            Constraints.Add(new PassableConstraint(7, B2andC1));
            Constraints.Add(new PassableConstraint(8, B2andC2));

            Constraints.Add(new PassableConstraint(6, B3andA1));
            Constraints.Add(new PassableConstraint(6, B3andB2));
            Constraints.Add(new PassableConstraint(8, B3andC2));
            Constraints.Add(new PassableConstraint(9, B3andC3));

            Constraints.Add(new PassableConstraint(7, C1andB1));
            Constraints.Add(new PassableConstraint(7, C1andB2));
            Constraints.Add(new PassableConstraint(8, C1andC2));

            Constraints.Add(new PassableConstraint(8, C2andB2));
            Constraints.Add(new PassableConstraint(8, C2andB3));
            Constraints.Add(new PassableConstraint(8, C2andC1));
            Constraints.Add(new PassableConstraint(9, C2andC3));

            Constraints.Add(new PassableConstraint(9, C3andB3));
            Constraints.Add(new PassableConstraint(9, C3andC2));
        }

        //A1 = 0
        //A2 = 1
        //A3 = 2
        //B1 = 3
        //B2 = 4
        //B3 = 5
        //C1 = 6
        //C2 = 7
        //C3 = 8

        //A1
        public bool A1andA2(List<Variable> VarInput) => VarInput[0].Guess != VarInput[1].Guess;
        public bool A1andB1(List<Variable> VarInput) => VarInput[0].Guess != VarInput[3].Guess;

        //A2
        public bool A2andA1(List<Variable> VarInput) => VarInput[1].Guess != VarInput[0].Guess;
        public bool A2andA3(List<Variable> VarInput) => VarInput[1].Guess != VarInput[2].Guess;
        public bool A2andB1(List<Variable> VarInput) => VarInput[1].Guess != VarInput[3].Guess;
        public bool A2andB2(List<Variable> VarInput) => VarInput[1].Guess != VarInput[4].Guess;

        //A3
        public bool A3andA2(List<Variable> VarInput) => VarInput[2].Guess != VarInput[1].Guess;
        public bool A3andB2(List<Variable> VarInput) => VarInput[2].Guess != VarInput[4].Guess;
        public bool A3andB3(List<Variable> VarInput) => VarInput[2].Guess != VarInput[5].Guess;

        //B17
        public bool B1andA1(List<Variable> VarInput) => VarInput[3].Guess != VarInput[0].Guess;
        public bool B1andA2(List<Variable> VarInput) => VarInput[3].Guess != VarInput[1].Guess;
        public bool B1andB2(List<Variable> VarInput) => VarInput[3].Guess != VarInput[4].Guess;
        public bool B1andC1(List<Variable> VarInput) => VarInput[3].Guess != VarInput[6].Guess;

        //B2
        public bool B2andA2(List<Variable> VarInput) => VarInput[4].Guess != VarInput[1].Guess;
        public bool B2andA3(List<Variable> VarInput) => VarInput[4].Guess != VarInput[2].Guess;
        public bool B2andB1(List<Variable> VarInput) => VarInput[4].Guess != VarInput[3].Guess;
        public bool B2andB3(List<Variable> VarInput) => VarInput[4].Guess != VarInput[5].Guess;
        public bool B2andC1(List<Variable> VarInput) => VarInput[4].Guess != VarInput[6].Guess;
        public bool B2andC2(List<Variable> VarInput) => VarInput[4].Guess != VarInput[7].Guess;

        //B3
        public bool B3andA1(List<Variable> VarInput) => VarInput[5].Guess != VarInput[0].Guess;
        public bool B3andB2(List<Variable> VarInput) => VarInput[5].Guess != VarInput[4].Guess;
        public bool B3andC2(List<Variable> VarInput) => VarInput[5].Guess != VarInput[7].Guess;
        public bool B3andC3(List<Variable> VarInput) => VarInput[5].Guess != VarInput[8].Guess;

        //C1
        public bool C1andB1(List<Variable> VarInput) => VarInput[6].Guess != VarInput[3].Guess;
        public bool C1andB2(List<Variable> VarInput) => VarInput[6].Guess != VarInput[4].Guess;
        public bool C1andC2(List<Variable> VarInput) => VarInput[6].Guess != VarInput[7].Guess;

        //C2
        public bool C2andB2(List<Variable> VarInput) => VarInput[7].Guess != VarInput[4].Guess;
        public bool C2andB3(List<Variable> VarInput) => VarInput[7].Guess != VarInput[5].Guess;
        public bool C2andC1(List<Variable> VarInput) => VarInput[7].Guess != VarInput[6].Guess;
        public bool C2andC3(List<Variable> VarInput) => VarInput[7].Guess != VarInput[8].Guess;

        //C3
        public bool C3andB3(List<Variable> VarInput) => VarInput[8].Guess != VarInput[5].Guess;
        public bool C3andC2(List<Variable> VarInput) => VarInput[8].Guess != VarInput[7].Guess;


        //make the constraints as functions here (lambdas) here, 
        //add the constraint functions to Constraints list
        //Length check will let me know which one to use



        //Neighbors
        //0: 1,3
        //1: 0,2,3,4
        //2: 1,4,5
        //3: 0,1,4,6
        //4: 1,2,3,5,6,7
        //5: 2,4,7,8
        //6: 3,4,7
        //7: 4,5,6,8
        //8: 5,7

        /*
        public override bool ConstraintFinder(List<Variable> VarInput)
        {

            bool checker = true;

            for(int i = 0; i < Constraints.Count; i ++)
            {
                if (Constraints[i].LengthCheck <= VarInput.Count)
                {
                    checker = checker && Constraints[i].Condition(VarInput);
                }

            }

            return checker;
        }
        */
        

    }
}
