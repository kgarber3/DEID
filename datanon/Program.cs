using System;
using System.Linq;

namespace datanon
{   
   class Program
    {
        public const int minAlphaRange = 1;
        public const int maxAlphaRange = 26;

        static void Main(string[] args)
        {   
            int offset = 4;
            int increment = 3; 
            string column = "123 main st. #209 6142716189";
            string newDeidString;

            Console.WriteLine(column);
            newDeidString = DeidString(column, offset, increment);
            Console.WriteLine(newDeidString);
        }

        public static string DeidString(string columnString, int charOffset, int offsetIncrement) {
            string newDeidString = ""; 
            char[] charArray = columnString.ToLower().ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                string letter;
                char activeChar = charArray[i];
                string activeLetter = charArray[i].ToString();
                int index = char.ToUpper(charArray[i]) - 64;

                if (Char.IsLetter(activeChar)){
                    letter = ProcessLetter(charOffset, index, activeLetter);
                }else if(Char.IsNumber(activeChar)){
                    letter = ProcessNumber(charOffset, index, activeLetter);
                }else {
                    letter = activeLetter;
                }

                newDeidString += letter;
                charOffset = charOffset + offsetIncrement;
            }

            return newDeidString;
        } 
        private static string numberStringConversion(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        private static string ProcessLetter(int charOffset, int currIndex, string currentLetter)
        {
            int newIndex = 0;
            int curr = currIndex;
            string letter;  
            for (int i = 0; i < charOffset; i++)
            {
                if (curr == maxAlphaRange)
                {
                    curr = minAlphaRange;
                }
                curr++;
            }

            newIndex = curr;

            if (newIndex > 0) {
                    letter = numberStringConversion(newIndex, false);
                } else {
                    letter = currentLetter;
            }
            return letter;
        }

        private static string ProcessNumber (int charOffset, int currIndex, string currentLetter)
        {
            int incomingNumber = Int32.Parse(currentLetter);
            string letter;  

            for (int i = 0; i < charOffset; i++)
            {
                
                if (incomingNumber + 1 > 9)
                {
                    incomingNumber = 0;
                    incomingNumber++;
                } else {
                    incomingNumber++;
                }
            }

            letter = incomingNumber.ToString();
            return letter;
        }
    }
}

