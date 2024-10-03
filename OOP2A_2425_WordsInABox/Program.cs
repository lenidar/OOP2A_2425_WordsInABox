using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OOP2A_2425_WordsInABox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Southville International School and Colleges";
            //string input = "Southville International School and Colleges - College of Information Technology and Engineering";
            // all i know at this point is my final output is a list of string
            List<string> finalOut = new List<string>();

            Console.WriteLine(input);
            finalOut = wordsInABox(input, 20);
            Console.WriteLine("\n\n");

            foreach(string word in finalOut)
                Console.WriteLine(word);

            Console.ReadKey();
        }

        static List<string> wordsInABox(string input, int charLen, char boxChar ='*')
        {
            List<string> output = new List<string>();

            output = arrangeWords(wordSplitter(input, ' '), charLen);
            output = putInBox(output, boxChar);

            return output;
        }

        static string[] wordSplitter(string input, char charSplit)
        {
            return input.Split(charSplit);
        }

        static List<string> arrangeWords(string[] words, int charLen)
        {
            List<string> arrangedWords = new List<string>();
            string temp = "";

            for(int x = 0; x < words.Length; x++)
            {
                if ( (temp + " " + words[x]).Length <= charLen)
                {
                    if(temp.Length == 0)
                        temp += words[x];
                    else
                        temp += " " + words[x];
                }
                else
                {
                    arrangedWords.Add(padToLength(temp, charLen));
                    temp = words[x];
                }
            }

            if (temp.Length > 0)
                arrangedWords.Add(padToLength(temp, charLen));

            return arrangedWords;
        }

        static string padToLength(string word, int length)
        {
            while(word.Length < length)
            {
                word += " ";
            }

            return word;
        }

        static List<string> putInBox(List<string> groups, char boxChar)
        {
            string lid = " ";

            for(int x = 0; x<groups.Count; x++)
            {
                groups[x] = $" {boxChar} {groups[x]} {boxChar}";
            }

            for(int x = 0; x < groups[0].Length - 1; x++)
            {
                lid += boxChar;
            }

            groups.Insert(0, lid);
            groups.Add(lid);

            return groups;
        }
    }
}
