namespace Markovian
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine();

            string text = File.ReadAllText(@"C:\Users\maxto\OneDrive\Documents\CodingCrap\MarkovianText.txt");


            string[] words = text.Split(' ');

            MarkovianChain MChain = new MarkovianChain(words[0], words);


        }
    }
}