using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LABA10MDK02; 

namespace LABA10MDK02.Tests
{
    [TestClass] 
    public class FileProcessorTests
    {
        private readonly string _testFolder = Path.Combine(Path.GetTempPath(), "LABA10MDK02_Tests");

        [TestInitialize]
        public void Setup()
        {
            if (Directory.Exists(_testFolder))
                Directory.Delete(_testFolder, true);
            Directory.CreateDirectory(_testFolder);
        }

        [TestMethod]
        public void RemoveEvenNumbers_ShouldRemoveEvens()
        {
            string inputPath = Path.Combine(_testFolder, "input_numbers.txt");
            string outputPath = Path.Combine(_testFolder, "output_numbers.txt");
            string inputContent = "10 21 32 43 54 65";
            File.WriteAllText(inputPath, inputContent);

            FileProcessor.RemoveEvenNumbers(inputPath, outputPath);

            Assert.IsTrue(File.Exists(outputPath), "Файл результата не был создан.");
            string result = File.ReadAllText(outputPath);
            Assert.AreEqual("21 43 65", result);
        }

        [TestMethod]
        public void ReverseWordsInLines_ShouldReverseOrder()
        {

            string inputPath = Path.Combine(_testFolder, "input_text.txt");
            string outputPath = Path.Combine(_testFolder, "output_text.txt");
            string inputContent = "Это простая строка";
            File.WriteAllText(inputPath, inputContent);
            FileProcessor.ReverseWordsInLines(inputPath, outputPath);
            Assert.IsTrue(File.Exists(outputPath));
            string result = File.ReadAllText(outputPath);
            Assert.AreEqual("строка простая Это", result);
        }

        [TestMethod]
        public void RemoveWordsLength3to5EvenCount_ShouldRemoveEvenCountOfWords()
        {
            string inputPath = Path.Combine(_testFolder, "input_words.txt");
            string outputPath = Path.Combine(_testFolder, "output_words.txt");
            string inputContent = "Слова разной длины: кот, медведь, лиса, волк, тигр";
            File.WriteAllText(inputPath, inputContent);
            FileProcessor.RemoveWordsLength3to5EvenCount(inputPath, outputPath);
            Assert.IsTrue(File.Exists(outputPath));
            string result = File.ReadAllText(outputPath);
            string[] resultWords = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in resultWords)
            {
                string cleanWord = word.Replace(",", "");
                if (cleanWord.Length >= 3 && cleanWord.Length <= 5)
                {
                    Assert.Fail($"В результате найдено слово '{word}' запрещенной длины.");
                }
            }
        }
    }
}