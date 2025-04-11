using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Humanizer;

namespace SpeedType
{
    public class SentenceProvider
    {
        public readonly string[] sentences;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="SentenceProvider"/> 
        /// class. Reads sentences from a file and stores them in an array. 
        /// If the file is not found, a default sentence is used.
        /// </summary>
        /// <remarks>
        /// This constructor attempts to read a file named "sentences.txt" 
        /// located in the directory two levels above the application's base 
        /// directory. Each line of the file is processed using the 
        /// <see cref="Humanizer"/> library's <c>Humanize()</c> method before 
        /// being added to the array. If the file does not exist, the array 
        /// will contain a single default sentence: "No Sentences Found! Please 
        /// Provide a File."
        /// </remarks>
        public SentenceProvider()
        {
            string textos = "sentences.txt";
            Random rand = new Random();

            string directoryPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"
                )
            );
            string filePath = Path.Combine(directoryPath, "sentences.txt");

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(textos))
                {
                    sentences.Append(line);
                }
            }
            else
            {
                sentences = new[] { "No Sentences Found! Please Provide a"
                    + " File." };
            }
        }

        /// <summary>
        /// Retrieves a random sentence from the array of sentences.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing a randomly selected sentence 
        /// from the array of sentences.
        /// </returns>
        public string GetRandomSentence()
        {
            Random rand = new Random();
            int n = rand.Next(0, sentences.Count() + 1);
            string sentence = sentences[n];
            return sentence;
        }
    }
}