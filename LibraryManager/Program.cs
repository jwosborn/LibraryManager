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

            //read from JSON file
            string jsonFilePath = "LibraryManager/data.json";
            byte[] json = File.ReadAllBytes(jsonFilePath);
            //cast bytes as List<Item>
            List<Item> itemsList = JsonSerializer.Deserialize<List<Item>>(json);

            void Write(){
                //serialize
                string jsonString = JsonSerializer.Serialize(itemsList);
                //write jsonString to JSON file
                System.IO.File.WriteAllText("./LibraryManager/data.json", jsonString);
            }

            Item getItem(List<Item> searchResult)
            {
                if (searchResult.Any())
                {
                    Console.WriteLine("Please enter the ID of the book you would like to Check out.");
                    for(int i = 0; i < searchResult.Count; i++)
                    {
                        Console.WriteLine($"ID: {i}, Title: {searchResult[i].Title}, Author: {searchResult[i].Author}");
                    } 
                int ID = Int32.Parse(Console.ReadLine());
                return itemsList.Find(x => x.Title.Equals(searchResult[ID].Title));
                } else 
                {
                    return null;
                }
            }
            //Master Loop
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
                            Write();
                            Console.Clear();
                            //success message
                            Console.WriteLine($"Item Added {newItem.Title}");
                            break;
                        }

                    case "2":
                    case "checkout":
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter the Title of the Book you would like to Check out.");
                            string searchTitle = Console.ReadLine();
                            List<Item> searchResult = itemsList.FindAll(x => x.Title.Contains(searchTitle) && x.OnLoan.Equals(false));
                            Item itemToLoan = null;
                            itemToLoan = getItem(searchResult);
                            if (itemToLoan != null && itemToLoan.OnLoan == false) 
                            {
                                Console.WriteLine("Please enter your Full Name");
                                var name = Console.ReadLine();
                                itemToLoan.OnLoan = true;
                                itemToLoan.Loanee = name;
                                Write();
                                Console.Clear();
                                //success message
                                Console.WriteLine($"Item Loaned: {itemToLoan.Title} to {itemToLoan.Loanee}");
                            } else 
                            {
                                Console.WriteLine("**** That Title is not found or is already Loaned out. Please try another title or come back later. ****");
                                break;
                            }
                            break;
                        }   
                    case "3":
                    case "return":
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter your full name");
                            string name = Console.ReadLine();
                            Item itemToReturn = null;
                            List<Item> itemsOnLoan = itemsList.FindAll(x => x.Loanee == name);
                            if (itemsOnLoan.Any())
                            {
                                itemToReturn = getItem(itemsOnLoan);
                                if(itemToReturn != null)
                                {
                                    itemToReturn.Loanee = "";
                                    itemToReturn.OnLoan = false;
                                    Write();                             
                                    Console.Clear();
                                    Console.WriteLine($"Book Returned: {itemToReturn.Title}.");
                                } else 
                                {
                                    Console.WriteLine("Please enter a valid selection.");
                                }
                            } else
                            {
                                Console.WriteLine($"****  No books found for Loanee: {name}. Please Try another name. ****");
                            }
                            break;
                        }
                    case "4":
                    case "remove":
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the title of the book you would like to remove permanently from the library.");
                            string searchTitle = Console.ReadLine();
                            List<Item> searchResult = itemsList.FindAll(x => x.Title.Contains(searchTitle));
                            Item itemToDelete;
                            itemToDelete = getItem(searchResult);
                            itemsList.Remove(itemToDelete);
                            Write();
                            Console.Clear();
                            Console.WriteLine($"Item Deleted: {itemToDelete.Title}");
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
