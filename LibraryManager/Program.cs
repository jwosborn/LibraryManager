using System;
using System.IO;

namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Welcome to the Osborn Family Library!
        ,         ,
        |\\\\ ////|
        | \\\V/// |
        |  |~~~|  |
        |  |===|  |
        |  |O  |  |
        |  | S |  |
         \ |  B| /
          \|===|/
           '---'
To check out or return a book, Please type 1 and hit Return.");
           var input = Console.ReadLine();
           if(input == "1") 
           {
              Console.WriteLine("Please Enter the Title of the book you wish to Loan."); 
              var bookSearch = Console.ReadLine();
           }
        }
    }
}
