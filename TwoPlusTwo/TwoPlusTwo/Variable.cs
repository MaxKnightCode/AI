using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPWeek
{
    public class Variable
    {

        public List<int> Domain;

        public int Guess;//the question mark is a wrapper called "system nullable" and allows int to be null

        public Variable(List<int> domain) 
        {
            Domain = domain;

        }



    }
}
