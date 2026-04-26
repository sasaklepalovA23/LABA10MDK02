using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace LABA10MDK02
{
    public static class FileProcessor 
    {
        public static void RemoveEvenNumbers(string inputFile, string outputFile)
        {
            var lines = File.ReadAllLines(inputFile);
            var result = new List<string>();
            foreach (var line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(word => int.TryParse(word, out _)).Select(int.Parse).Where(n => n % 2 != 0).Select(n => n.ToString());
                result.Add(string.Join(" ", numbers));
            }
            File.WriteAllText(outputFile, string.Join("\r\n", result));
        }

        public static void ReverseWordsInLines(string inputFile, string outputFile)
        {
            var lines = File.ReadAllLines(inputFile);
            var result = lines.Select(line =>
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(words);
                return string.Join(" ", words);
            });
            File.WriteAllText(outputFile, string.Join("\r\n", result));
        }

        public static void RemoveWordsLength3to5EvenCount(string inputFile, string outputFile)
        {
            var lines = File.ReadAllLines(inputFile);
            var result = new List<string>();
            foreach (var line in lines)
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                var toRemove = words.Where(w => w.Length >= 3 && w.Length <= 5).ToList();
                int countToRemove = toRemove.Count % 2 == 0 ? toRemove.Count : toRemove.Count - 1;
                for (int i = 0; i < countToRemove; i++)
                    words.Remove(toRemove[i]);
                result.Add(string.Join(" ", words));
            }
            File.WriteAllLines(outputFile, result);
        }

        public static void AlignRight(string inputFile, string outputFile)
        {
            var lines = File.ReadAllLines(inputFile);
            int maxLength = lines.Max(l => l.Length);
            var result = lines.Select(l => l.PadLeft(maxLength));
            File.WriteAllLines(outputFile, result);
        }
    }
}