using LexerObj = Lexer.Validate.App.Utils.Lexer;

class Program
{
    static void Main()
    {

        string filePath = "Files\\input.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        List<string> lines = File.ReadAllLines(filePath).ToList();

        foreach (string line in lines)
        {
            LexerObj.Tokenize(line);
        }
    }
}
