using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<=[\s]):([a-z]{4,}):([ ,.!?])";
            List<string> emojiesList = new List<string>();
            int totalPower = 0;

            string inputText = Console.ReadLine();
            string inputEmojiCode = Console.ReadLine();

            int[] inputEmojiArr = inputEmojiCode
                .Split(":")
                .Select(int.Parse)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < inputEmojiArr.Length; i++)
            {

                char letter = (char)inputEmojiArr[i];
                sb.Append(letter);
            }
            string inputEmoji = sb.ToString();

            MatchCollection emojies = Regex.Matches(inputText, regex);
            foreach (Match emoji in emojies)
            {
                string currentEmoji = emoji.Groups[1].Value;
                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    totalPower += currentEmoji[i];
                }
                emojiesList.Add(currentEmoji);
            }
            if (emojiesList.Contains(inputEmoji))
            {
                totalPower *= 2;
            }
            if (emojiesList.Count > 0)
            {
                Console.WriteLine($"Emojis found: {":" + string.Join(":, :", emojiesList) + ":"}");
            }
            Console.WriteLine($"Total Emoji Power: {totalPower}");
        }
    }
}
