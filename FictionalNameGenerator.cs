using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveArr.Utility
{
    /// <summary>
    /// Generates fictional names.  Best for use in science fiction and fantasy.
    /// </summary>
    public static class FictionalNameGenerator
    {
        /// <summary>
        /// Generate a random fictional name with a length between 3 and 9 characters.
        /// </summary>
        /// <returns>Fictional name.</returns>
        public static string Generate()
        {
            return Generate(3, 9);
        }

        /// <summary>
        /// Generate a random fictional name with a user-defined length.
        /// </summary>
        /// <param name="minLength">Minimum name length.</param>
        /// <param name="maxLength">Maximum name length.</param>
        /// <returns>Fictional name.</returns>
        public static string Generate(int minLength, int maxLength)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            char[] consonants = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
            char character;
            bool doubleChar = false;            

            int nameLength = random.Next(minLength, maxLength);

            sb.Append(RandomChar(random, consonants).ToString().ToUpper());

            for (int i = 1; i < nameLength; i++)
            {
                //1 in 20 chance of having a double-character.
                if (i <= nameLength - 1 && random.Next(20) == 1) doubleChar = true;

                if (i % 2 == 1)
                    character = RandomChar(random, vowels);
                else
                    character = RandomChar(random, consonants);

                sb.Append(character);
                if(doubleChar)
                {
                    sb.Append(character);
                    doubleChar = false;
                    i++;
                }
            }

            return sb.ToString();
        }

        private static char RandomChar(Random random, char[] charList)
        {
            return charList[random.Next(1, charList.Length)];
        }
    }
}
