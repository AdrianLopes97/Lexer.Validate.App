using System.Text;

namespace Lexer.Validate.App.Utils
{
    public static class Lexer
    {
        /// <summary>
        /// Tokenizes the input string into operators, numbers, and identifiers.
        /// </summary>
        /// <param name="input">The input string to tokenize.</param>
        public static void Tokenize(string input)
        {
            var operators = new[] { '+', '-', '*', '/', '=' };

            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];

                    if (char.IsWhiteSpace(c))
                    {
                        continue;
                    }
                    else if (operators.Contains(c))
                    {
                        HandleOperator(c);
                    }
                    else if (char.IsDigit(c))
                    {
                        i = HandleNumber(input, i);
                    }
                    else if (char.IsLetterOrDigit(c) || c == '_')
                    {
                        i = HandleIdentifier(input, i);
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Token: ->{input}<- not recognized!");
            }
        }

        /// <summary>
        /// Handles the tokenization of operators.
        /// </summary>
        /// <param name="c">The operator character.</param>
        private static void HandleOperator(char c)
        {
            PrintToken("TOKEN_OP", c.ToString());
        }

        /// <summary>
        /// Handles the tokenization of numbers.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="startIndex">The starting index of the number.</param>
        /// <returns>The updated index after processing the number.</returns>
        private static int HandleNumber(string input, int startIndex)
        {
            var number = new StringBuilder();
            int i = startIndex;

            while (i < input.Length && char.IsDigit(input[i]))
            {
                number.Append(input[i]);
                i++;
            }
            i--; // Adjust the index after the loop
            PrintToken("TOKEN_NUM", number.ToString());

            return i;
        }

        /// <summary>
        /// Handles the tokenization of identifiers.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="startIndex">The starting index of the identifier.</param>
        /// <returns>The updated index after processing the identifier.</returns>
        private static int HandleIdentifier(string input, int startIndex)
        {
            var identifier = new StringBuilder();
            int i = startIndex;

            while (i < input.Length && (char.IsLetterOrDigit(input[i]) || input[i] == '_'))
            {
                identifier.Append(input[i]);
                i++;
            }
            i--; // Adjust the index after the loop
            PrintToken("TOKEN_ID", identifier.ToString());

            return i;
        }

        /// <summary>
        /// Prints the token type and content to the console.
        /// </summary>
        /// <param name="type">The type of the token.</param>
        /// <param name="content">The content of the token.</param>
        private static void PrintToken(string type, string content)
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Content: {content}");
            Console.WriteLine("________________________\n");
        }
    }
}
