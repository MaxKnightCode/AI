using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markovian
{
    public class MarkovianChain
    {

        public string[] FullText;
        public List<string> Scramble;

        public string EndPoint;

        public MarkovianChain(string firstWord, string[] fullText)
        {
            FullText = fullText;
            Scramble = new List<string>();

            EndPoint = FullText[FullText.Length - 1];

            DictionaryBuilder();
            BuildChain(firstWord);

            PrintScramble();
        }



        public Dictionary<string, List<string>> FullTextDictionary;


        public void DictionaryBuilder()
        {
            FullTextDictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < FullText.Length; i++)
            {
                List<string> temp = new();

                for (int f = 0; f < FullText.Length; f++)
                {
                    if (FullText[i].ToString() == FullText[f].ToString() && FullText[i] != EndPoint)
                    {
                        temp.Add(FullText[f + 1]);
                    }
                }

                if (FullTextDictionary.Keys.Contains(FullText[i].ToString()))
                {
                    for (int x = 0; x < temp.Count; x++)
                    {
                        FullTextDictionary[FullText[i].ToString()].Add(temp[x]);
                    }
                }
                else
                {
                    FullTextDictionary.Add(FullText[i], temp);
                }
            }
        }


        public List<string> BuildChain(string FirstWord)
        {
            Random gen = new Random(1);
            Scramble.Add(FirstWord);

            int index = 0;

            while (Scramble.Count <= FullText.Length)
            {
                string ScrambleToAdd;

                

                if (FullTextDictionary[Scramble[index]].Count == 0)
                {
                    ScrambleToAdd = FullText[gen.Next(FullText.Length-1)];
                }
                else
                {
                    int randoIndx = gen.Next(FullTextDictionary[Scramble[index]].Count - 1);
                    ScrambleToAdd = FullTextDictionary[Scramble[index]][randoIndx];
                }


                Scramble.Add(ScrambleToAdd);

                index++;
            }

            return Scramble;
        }

        public void PrintScramble()
        {
            for(int i = 0; i < Scramble.Count; i++)
            {
                Console.Write($"{Scramble[i]} ");
            }
        }

    }
}
