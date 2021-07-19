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
To Add a Book to the Library, Please type add or 1 and hit Return. 
To Checkout a book, Please type checkout or 2 and hit Return.
To Return a book, Please type return or 3 and hit Return.");
           var menuInput = Console.ReadLine().ToLower();

            //convert this to switch statement
           if(menuInput == "1" || menuInput == "add") 
           {
              Console.WriteLine("Please Enter the Title of the book you wish to add."); 
              var newBookTitle = Console.ReadLine();
              Console.WriteLine("Please Enter the Author of the book you wish to add."); 
              var newBookAuthor = Console.ReadLine();
           } else if(menuInput == "2" || menuInput == "checkout") 
           {
               Console.WriteLine("Please Enter the Title of the book you would like to loan.");
               var bookSearch = Console.ReadLine();
               Console.WriteLine("Please enter your full name.");
               var bookLoanee = Console.ReadLine();
           } else if(menuInput == "3" || menuInput == "return")
           {
               Console.WriteLine("");
           }
        }
    }
}
