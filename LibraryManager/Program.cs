using System;
using System.IO;

namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            while(keepGoing)
            {
            Console.WriteLine(@"Welcome to the Osborn Family Library Management App.
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
To Return a book, Please type return or 3 and hit Return.
To Exit, Please type exit or 4 and hit Return.");
           var menuInput = Console.ReadLine().ToLower();

                switch (menuInput)
                {
                    case "1":
                    case "add":
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter the Title of the book you wish to add.");
                            var newBookTitle = Console.ReadLine();
                            Console.WriteLine("Please Enter the Author of the book you wish to add.");
                            var newBookAuthor = Console.ReadLine();
                            break;
                        }

                    case "2":
                    case "checkout":
                        Console.Clear();
                        break;
                    case "3":
                    case "return":
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter the Title of the book you are returning.");
                            var bookSearchTitle = Console.ReadLine();
                            BookSearch bookSearch = new BookSearch();
                            var searchList = bookSearch.Search(bookSearchTitle);
                            Console.WriteLine(searchList);
                            break;
                        }

                    case "4":
                    case "exit":
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        keepGoing = false;
                        break;
                    }

                    default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid choice");
                        break;
                    }
                }
            }
    }
    }
}
