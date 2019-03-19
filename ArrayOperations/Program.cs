using System;

namespace ArrayOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            Operations op = new Operations();
            op.start();
      
            Console.ReadLine();
        }
    }
}
