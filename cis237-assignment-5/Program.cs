/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 5

using cis237_assignment_5.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Runtime.CompilerServices;

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

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();
            
            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // Loop while the choice is not exit program
            while (choice != userInterface.MenuExitNumber)
            {
                // Which choice did the user make from the menu
                switch (choice)
                {
                    // Display all items
                    case 1:
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
                        // Get the Id the user wants
                        string searchQueryString = userInterface.GetQuery("search for");

                        // Get item information
                        string itemInformationString = beverageCollection.FindBeverageInformationById(searchQueryString);

                        // Check that the item was found
                        if (itemInformationString != null)
                        {
                            // Diaplay the found item
                            userInterface.DisplayItemFound(itemInformationString);

                        }
                        // Item was not found in the collection
                        else
                        {
                            // Display item not not found error
                            userInterface.DisplayItemFoundError();

                        }

                        break;

                    // Add an item to the list
                    case 3:
                        // Get the Id the user wants
                        string additionQueryString = userInterface.GetQuery("add");                        

                        // Check that the item does not already exist in the database
                        if (beverageCollection.FindBeverageInformationById(additionQueryString) == null)
                        {
                            // Get new item information and set it as elements in an array of strings
                            string[] newItemInformation = userInterface.GetNewItemInformation();

                            // Add the new beverage to the database and get if this was successful
                            bool beverageAddedBool = beverageCollection.AddNewBeverage(additionQueryString,
                                                                                       newItemInformation[0],
                                                                                       newItemInformation[1],
                                                                                       decimal.Parse(newItemInformation[2]),
                                                                                       (newItemInformation[3] == "True"));

                            // Check if the beverage was successfully added
                            if (beverageAddedBool)
                            {
                                // Display success message
                                userInterface.DisplayAddItemSuccess();

                            }
                            // The beverage was not added successfully
                            else
                            {
                                // Display failure message
                                userInterface.DisplayAddItemError();

                            }                                                        

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
                        // Get the Id the user wants
                        string editQueryString = userInterface.GetQuery("edit");

                        // Check that item exists in the database
                        if (beverageCollection.FindBeverageInformationById(editQueryString) != null)
                        {
                            // Get conformations on which attributes the user will edit
                            string[] editedItemInformtion = userInterface.GetEditedInformation();

                            // Edit the beverage in the database and get if this was successful
                            bool beverageEditedBool = beverageCollection.EditBeverage(editQueryString,
                                                                                      editedItemInformtion[0],
                                                                                      editedItemInformtion[1],
                                                                                      editedItemInformtion[2],
                                                                                      editedItemInformtion[3]);

                            // Check that the beverage was successfully edited
                            if (beverageEditedBool)
                            {
                                // Display success message
                                userInterface.DisplayEditItemSuccess();

                            }
                            //
                            else
                            {
                                // Display failure message
                                userInterface.DisplayEditItemError();

                            }

                        }
                        // Item was not found in the collection
                        else
                        {
                            // Display item not not found error
                            userInterface.DisplayItemFoundError();

                        }

                        break;

                    // Delete an item from the list
                    case 5:
                        // Get the Id the user wants to remove from the collection
                        string deleteQueryString = userInterface.GetQuery("delete");

                        // Check that item exists in the database
                        if (beverageCollection.FindBeverageInformationById(deleteQueryString) != null)
                        {
                            // Remove the item from the database and get if this was successful
                            bool beverageDeletedBool = beverageCollection.DeleteBeverage(deleteQueryString);

                            // Check if the beverage was successfully deleted
                            if (beverageDeletedBool)
                            {
                                // Display success message
                                userInterface.DisplayDeleteItemSuccess();

                            }
                            // The beverage was not deleted successfully
                            else
                            {
                                // Display failure message
                                userInterface.DisplayDeleteItemError();

                            }

                        }
                        // Item was not found in the collection
                        else
                        {
                            // Display item not not found error
                            userInterface.DisplayItemFoundError();

                        }

                        break;

                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();

            }

        }

    }

}
