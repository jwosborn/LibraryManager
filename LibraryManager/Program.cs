using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
To Remove a book, Please type remove or 4 and hit Return.
To Exit, Please type exit or 5 and hit Return.");
           var menuInput = Console.ReadLine().ToLower();

                switch (menuInput)
                {
                    case "1":
                    case "add":
                        {
                            //read from JSON file
                            string jsonFilePath = "LibraryManager/data.json";
                            byte[] json = File.ReadAllBytes(jsonFilePath);
                            //cast bytes as List<Item>
                            List<Item> itemsList = JsonSerializer.Deserialize<List<Item>>(json);
                            Console.Clear();
                            Console.WriteLine("Please Enter the Title of the book you wish to add.");
                            var newBookTitle = Console.ReadLine();
                            Console.WriteLine("Please Enter the Author of the book you wish to add.");
                            var newBookAuthor = Console.ReadLine();
                            //Cast user input as new Item
                            Item newItem = new Item
                            {
                                Title = newBookTitle, 
                                Author = newBookAuthor, 
                                OnLoan = false,
                                Loanee = ""
                            };
                            //add new item to previous list read from JSON file
                            itemsList.Add(newItem);
                            //serialize to JSON
                            string jsonString = JsonSerializer.Serialize(itemsList);
                            //write jsonString to JSON file
                            System.IO.File.WriteAllText("./LibraryManager/data.json", jsonString);
                            //success message
                            Console.WriteLine($"Item Added {newItem.Title}");
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
                    case "remove":
                        {
                            //read from JSON file
                            string jsonFilePath = "LibraryManager/data.json";
                            byte[] json = File.ReadAllBytes(jsonFilePath);
                            //cast bytes as List<Item>
                            List<Item> itemsList = JsonSerializer.Deserialize<List<Item>>(json);
                            Console.Clear();
                            Console.WriteLine("Please enter the title of the book you would like to remove permanently from the library.");
                            string searchTitle = Console.ReadLine();
                            break;
                        }
                    case "5":
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
