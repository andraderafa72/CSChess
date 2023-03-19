namespace CSChess
{
    class Chess
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(" _ ");
                }
                Console.WriteLine("");
            }
        }
    }
}