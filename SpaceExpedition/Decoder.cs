using System;
namespace SpaceExpedition
{
    internal class Decoder
    {
        public static string DecodeArtifactName(string encodedName)
        {
            string decodedName = "";

            string[] tokens = encodedName.Split('|');
            for (int i =0; i < tokens.Length; i++)
            {
                string token = tokens[i].Trim();

                char letter;
                int level;

               if(GetLetterAndLevel(token,out letter, out level))
                {
                    decodedName = decodedName + DecodeLetter(letter, level);
                }
                else
                {
                    Console.WriteLine("Warning : Bad token : " + token);
                }
            }
            return decodedName;
            
        }
        private static bool GetLetterAndLevel (string token,out char letter,out int level)
        {
            letter = 'A';
            level = 0;
            if(token == null)
            {
                return false;
            }
            token = token.Trim();
            if(token.Length < 2)
            {
                return false;
            }
            letter = char.ToUpper(token[0]);
            if (letter < 'A' || letter > 'Z')
            {
                return false;
            }
            string numberPart = token.Substring(1);

            if (!int.TryParse(numberPart, out level))
            {
                return false;
            }
            return true;
        }
        private static char DecodeLetter (char letter , int level)
        {
            if(level <= 0)
            {
                return Mirror(letter);
            }
            char newLetter = Map(letter);
            return DecodeLetter(newLetter, level - 1);
        }
        private static char Mirror(char c)

        {
            int offset = c - 'A';
            char result = (char)('Z' - offset);
            return result ;
        }
        private static char Map(char c)

        {
            char[] original =
            {
                 'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            char[] mapped =
            {
               'H','Z','A','U','Y','E','K','G','O','T','I','R','J',
                 'V','W','N','M','F','Q','S','D','B','X','L','C','P'
            };
            for( int i = 0; i < original.Length; i++)
            {
                if (original[i] == c)
                {
                    return mapped[i];
                }
            }
            return c;
        }
     
    }
}
