using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10065470_PROG6221_POE
{
    public class ErrorChecking
    {
        public static double CheckForPositiveNumber(string userInput)
        {
            try
            {
                // try to parse user input as a double and check if the number is greater than or equal to 0
                double input = double.Parse(userInput);
                if (input >= 0)
                {
                    return input; // return the input if successful
                }
                else
                {
                    throw new Exception(); // throw an exception if the input is less than 0
                }
            }
            catch
            {
                // if parsing as a double fails, try to convert the input to a double using the WordToDouble method
                double wordValue = WordToDouble(userInput);
                if (wordValue >= 0)
                {
                    return wordValue; // return the word value if successful
                }
                else
                {
                    return -1; // return -1 to indicate failure
                }
            }
        }

        //Title: C# method to convert a word to a number (double)
        //Author: ChatGPT
        //Date: 2023-04-25

        // Source: https://github.com/openai/gpt-3-examples/blob/main/csharp/word-to-double-converter.cs
        //Availability: https://github.com/ChatGPT/Code-Samples/blob/main/CSharp/WordToDouble.cs

        // OpenAI is a research organization that aims to ensure that artificial intelligence (AI) benefits humanity. 
        // They are known for their work in developing natural language processing (NLP) and AI models, including GPT-3. 
        // For more information, visit their website at https://openai.com/.

        // Russell Schwedhelm is the author of this adapted code. This version includes modifications to fit specific use cases.

        //This method converts an enetered word to a double
        private static double WordToDouble(string userInput)
        {
            userInput = userInput.ToLower();
            // Define a dictionary of number words and their corresponding numeric values
            Dictionary<string, double> numberWords = new Dictionary<string, double>()
            {
                {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5}, {"six", 6},
                {"seven", 7}, {"eight", 8}, {"nine", 9}, {"ten", 10}, {"eleven", 11}, {"twelve", 12},
                {"thirteen", 13}, {"fourteen", 14}, {"fifteen", 15}, {"sixteen", 16}, {"seventeen", 17},
                {"eighteen", 18}, {"nineteen", 19}, {"twenty", 20}, {"thirty", 30}, {"forty", 40}, {"fifty", 50},
                {"sixty", 60}, {"seventy", 70}, {"eighty", 80}, {"ninety", 90}, {"hundred", 100}, {"thousand", 1000},
                {"million", 1000000}, {"billion", 1000000000},
            };

            double totalValue = 0;
            double chunkValue = 0;
            bool hasHundred = false;

            string[] words = userInput.Split(' ', '-');
            foreach (string w in words)
            {
                if (numberWords.TryGetValue(w, out double value))
                {
                    if (value >= 100)
                    {
                        if (hasHundred)
                        {
                            return 0;
                        }
                        chunkValue *= value;
                        hasHundred = true;
                    }
                    else
                    {
                        chunkValue += value;
                    }
                }
                else if (w.Equals("and"))
                {
                    // do nothing
                }
                else
                {
                    return -1;
                }
            }

            if (chunkValue == 0 && hasHundred)
            {
                chunkValue = 100;
            }

            totalValue += chunkValue;

            return totalValue;
        }

    }
}
