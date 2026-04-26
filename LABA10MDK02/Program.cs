using System;
using LABA10MDK02; 

namespace LABA10MDK02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "input.txt";

            FileProcessor.RemoveEvenNumbers(input, "output1.txt");
            FileProcessor.ReverseWordsInLines(input, "output2.txt");
            FileProcessor.RemoveWordsLength3to5EvenCount(input, "output3.txt");
            FileProcessor.AlignRight(input, "output4.txt");

            Console.WriteLine("Готово!");
        }
    }
}