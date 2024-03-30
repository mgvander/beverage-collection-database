/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 5

using cis237_assignment_5.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace cis237_assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Set Console Window Size
            //Console.BufferHeight = Int16.MaxValue - 1;
            //Console.WindowHeight = 40;
            Console.WindowWidth = 151;            

            //// Set a constant for the size of the collection
            //const int beverageCollectionSize = 4000;

            //// Number to exit the program
            //const int exitInteger = 6;

            //// Set a constant for the path to the CSV File
            //const string pathToCSVFile = "../../../../datafiles/beverage_list.csv";

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();
            
            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection();

            //// Create an instance of the CSVProcessor class
            //CSVProcessor csvProcessor = new CSVProcessor();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // Loop while the choice is not exit program
            while (choice != userInterface.MenuExitNumber)
            {
                switch (choice)
                {
                    // Display all items
                    case 1:
                        //// Load the CSV File
                        //bool success = csvProcessor.ImportCSV(beverageCollection, pathToCSVFile);
                        //if (success)
                        //{
                        //    // Display Success Message
                        //    userInterface.DisplayImportSuccess();
                        //}
                        //else
                        //{
                        //    // Display Fail Message
                        //    userInterface.DisplayImportError();
                        //}

                        //// Print Entire List Of Items
                        //string allItemsString = beverageCollection.ToString();

                        //if (!String.IsNullOrWhiteSpace(allItemsString))
                        //{
                        //    // Display all of the items
                        //    userInterface.DisplayAllItems(allItemsString);
                        //}
                        //else
                        //{
                        //    // Display error message for all items
                        //    userInterface.DisplayAllItemsError();
                        //}

                        // Create a string of the full item list
                        string allItemsString = beverageCollection.ToString();

                        // Check the list of items is not null and is more than white spaces
                        if (!String.IsNullOrWhiteSpace(allItemsString))
                        {
                            // Display all of the items
                            userInterface.DisplayAllItems(allItemsString);

                        }
                        else
                        {
                            // Display error message for all items
                            userInterface.DisplayAllItemsError();

                        }

                        break;

                    // Find an item from the list
                    case 2:
                        //// Search For An Item
                        //string searchQuery = userInterface.GetSearchQuery();
                        //string itemInformation = beverageCollection.FindById(searchQueryString);
                        //if (itemInformationString != null)
                        //{
                        //    userInterface.DisplayItemFound(itemInformationString);
                        //}
                        //else
                        //{
                        //    userInterface.DisplayItemFoundError();
                        //}

                        // Get the Id the user wants
                        string searchQueryString = userInterface.GetSearchQuery();

                        // Get item information
                        string itemInformationString = beverageCollection.FindById(searchQueryString);

                        // Check that the item was found
                        if (itemInformationString != null)
                        {
                            // Diaplay the found item
                            userInterface.DisplayItemFound(itemInformationString);

                        }
                        // Item was not found
                        else
                        {
                            // Display item not not found error
                            userInterface.DisplayItemFoundError();

                        }

                        break;

                    // Add an item to the list
                    case 3:
                        // Get new item information and set it as elements in an array of strings
                        string[] newItemInformation = userInterface.GetNewItemInformation();

                        // Check that the item does not already exist in the database
                        if (beverageCollection.FindById(newItemInformation[0]) == null)
                        {
                            // Add the new item to the database
                            beverageCollection.AddNewItem(newItemInformation[0],
                                                          newItemInformation[1],
                                                          newItemInformation[2],
                                                          decimal.Parse(newItemInformation[3]),
                                                          (newItemInformation[4] == "True"));

                            // Display success message
                            userInterface.DisplayAddBeverageSuccess();

                        }
                        // The item's id was found to already exist in the database
                        else
                        {
                            // Display item already exists message
                            userInterface.DisplayItemAlreadyExistsError();

                        }

                        break;

                    // Edit an item in the list
                    case 4:
                        

                        break;

                    // Delete an item from the list
                    case 5:


                        break;

                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();

            }

        }

    }

}
