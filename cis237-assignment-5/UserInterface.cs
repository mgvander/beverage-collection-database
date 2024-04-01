/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 5

using System;

namespace cis237_assignment_5
{
    class UserInterface
    {
        // The number of choices in the main menu
        private const int MAX_MENU_CHOICES = 6;

        /********************************************************************************
         * Properties
         * *****************************************************************************/
        // The integer menu choice that ends the program
        public int MenuExitNumber { get { return MAX_MENU_CHOICES; } }

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the wine program!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        // Get the search query from the user
        public string GetQuery(string passField)
        {
            Console.WriteLine();
            Console.WriteLine($"What Item Id would you like to {passField}?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        // Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            // Get and set Beverage data fields fromt he user
            string name = this.GetStringField("Name");
            string pack = this.GetStringField("Pack");
            string price = this.GetDecimalField("Price");
            string active = this.GetBoolField("Active");
            
            // Return a string array of the Beverage's data fields
            return new string[] { name, pack, price, active };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetEditedInformation()
        {
            // Beverage data fields
            string nameString = "";
            string packString = "";
            string priceString = "";
            string activeString = "";

            // Get the editing conformation for the Beverage's
            bool editNameBool = this.GetEditQuery("Name");

            // Does the user want to edit the name
            if (editNameBool)
            {
                // Get the new name
                nameString = this.GetStringField("Name");

            }

            // Get the editing conformation for the Beverage's
            bool editPackBool = this.GetEditQuery("Pack");

            // Does the user want to edit the pack
            if (editPackBool)
            {
                // Get the new pack
                packString = this.GetStringField("Pack");

            }

            // Get the editing conformation for the Beverage's
            bool editPriceBool = this.GetEditQuery("Price");

            // Does the user want to edit the price
            if (editPriceBool)
            {
                // Get the new price
                priceString = this.GetDecimalField("Price");

            }

            // Get the editing conformation for the Beverage's
            bool editActiveBool = this.GetEditQuery("Active Status");

            // Does the user want to edit the active status
            if (editActiveBool)
            {
                // Get the new active status
                activeString = this.GetBoolField("Active");

            }

            return new string[] { nameString, packString, priceString, activeString};

        }

        // Display Import Success
        //public void DisplayImportSuccess()
        //{
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("Wine List Has Been Imported Successfully");
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}

        // Display Import Error
        //public void DisplayImportError()
        //{
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine("There was an error importing the CSV");
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}

        // Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(allItemsOutput);

        }

        // Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no items in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item Was Not Found");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Add Item Success
        public void DisplayAddItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The item was successfully added");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Add Item Error Message
        /// </summary>
        public void DisplayAddItemError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item Couldn't Be Added");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Edit Item Success Message
        /// </summary>
        public void DisplayEditItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All item changes have been been saved");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public void DisplayEditItemError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item Couldn't Be Changed");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        /// <summary>
        /// Display Delete Item Success Message
        /// </summary>
        public void DisplayDeleteItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The item was successfully deleted");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        /// <summary>
        /// Display Delete Item Error Message
        /// </summary>
        public void DisplayDeleteItemError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item Couldn't Be Deleted");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print the Entire List of Items");
            Console.WriteLine("2. Search for an Item");
            Console.WriteLine("3. Add New Item to the List");
            Console.WriteLine("4. Edit an Item in the List");
            Console.WriteLine("5. Delete an Item in the List");
            Console.WriteLine("6. Exit Program");
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        // Get the selection from the user
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        // Verify that a selection from the main menu is valid
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        // Get a valid string field from the console
        private string GetStringField(string fieldName)
        {
            Console.WriteLine("What is the Item's {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get a valid decimal field from the console
        private string GetDecimalField(string fieldName)
        {
            Console.WriteLine("What is the Item's {0}", fieldName);
            Console.Write("> $");
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> $");
                }
            }

            return value.ToString();
        }

        // Get a valid bool field from the console
        private string GetBoolField(string fieldName)
        {
            Console.WriteLine("Should the Item be {0}? (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        private bool GetEditQuery(string passfieldNameString)
        {
            // User's input
            string inputString = null;

            // Should the data field be edited
            bool valueBool = false;

            // Is the user's input a valid response
            bool validBool = false;

            // Display prompt
            Console.WriteLine($"Would you like to change the item's {passfieldNameString}? (y/n)");

            // Loop while the user's input is not valid
            while (!validBool)
            {
                // Get user's input
                inputString = Console.ReadLine();

                // Check for one of the two valid inputs
                if (inputString.ToLower() == "y" || inputString.ToLower() == "n")
                {
                    // The input was valid
                    validBool = true;

                    // Convert y/n to true/false
                    valueBool = (inputString.ToLower() == "y");

                }
                // The user's input was not valid
                else
                {
                    // Display the error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();

                    // Display prompt
                    Console.WriteLine($"Would you like to change the item's {passfieldNameString}? (y/n)");

                }

            }

            // Return boolean value
            return valueBool;

        }

        // Get a string formatted as a header for items
        private string GetItemHeader()
        {
            // Format the beverage header
            return "Id Code:".PadRight(9)
                 + "Beverage Name:".PadRight(100)
                 + "Packaging:".PadRight(19)
                 + "Price:".PadLeft(7) + "  " 
                 + "Active Status:".PadRight(6) + Environment.NewLine
                 + "".PadRight(151, '-');

        }
    }
}
