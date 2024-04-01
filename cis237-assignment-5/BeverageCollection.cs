/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 5

using cis237_assignment_5.Models;
using System;
using System.Data.SqlTypes;

namespace cis237_assignment_5
{
    class BeverageCollection
    {
        private BeverageContext beverageContext = new BeverageContext();

        // Add a new item to the collection
        // Return the success status of the beverage addition
        public bool AddNewBeverage(string passIdString,
                                   string passNameString,
                                   string passPackString,
                                   decimal passPriceDecimal,
                                   bool passActiveBool)
        {
            // Make a new instance of a beverage
            Beverage newBeverage = new Beverage();

            // Has the beverage been added?
            bool beverageAddedBool = false;

            // Set Id, name, packing, price, and activity
            newBeverage.Id = passIdString;
            newBeverage.Name = passNameString;
            newBeverage.Pack = passPackString;
            newBeverage.Price = passPriceDecimal;
            newBeverage.Active = passActiveBool;

            // Try to add the beverage
            try
            {
                // Add the new beverage to the beverage collection
                beverageContext.Beverages.Add(newBeverage);

                // Save changes to the beverage collection
                beverageContext.SaveChanges();

                // Beverage was added
                beverageAddedBool = true;

            }
            // The beverage was not added (a beverage with the same Key Attribute already existing in the list
            // could cause this)
            catch
            {
                // The new beverage could not be added so it should be removed since it could not be saved
                // It should not be left in suspension the next time a new beverage is being added and saved.
                beverageContext.Remove(newBeverage);

            }

            // Return if the beverage was added
            return beverageAddedBool;

        }

        /// <summary>
        /// Change the data stored in a Beverage's properties: Name, Pack, Price, and/or Active.
        /// Passed strings of null, empty, or only white-space characters, do not replace a Beverage property's set value.
        /// </summary>
        /// <param name="passIdString"> Beverage Id </param>
        /// <param name="passNameString"> Beverage Name </param>
        /// <param name="passPackString"> Beverage Pack </param>
        /// <param name="passPriceString"> Beverage Price </param>
        /// <param name="passActiveString"> Beverage Active </param>
        /// <returns> True if all updates are successfully saved </returns>
        public bool EditBeverage(string passIdString,
                                 string passNameString,
                                 string passPackString,
                                 string passPriceString,
                                 string passActiveString)
        {
            // Try to find and get the beverage from the collection
            Beverage beverageToEdit = beverageContext.Beverages.Find(passIdString);

            // Has the beverage been edited
            bool beverageEditedBool = false;

            // Check that a beverage with the passed in key exists in the collection
            if (beverageToEdit != null)
            {
                // Check for a new name
                if (!String.IsNullOrWhiteSpace(passNameString))
                {
                    // Set the new name
                    beverageToEdit.Name = passNameString;

                }

                // Check for a new pack
                if (!String.IsNullOrWhiteSpace(passPackString))
                {
                    // Set the new pack
                    beverageToEdit.Pack = passPackString;

                }

                // Check for a new price
                if (!String.IsNullOrWhiteSpace(passPriceString))
                {
                    // Try to set the new price
                    try
                    {
                        // Set the new price
                        beverageToEdit.Price = decimal.Parse(passPriceString);

                    }
                    catch
                    {
                        // The string was not converted to decimal type
                        return beverageEditedBool;

                    }

                }

                // Check for a new active status
                if (!String.IsNullOrWhiteSpace(passActiveString))
                {
                    // Check that the string represents a bollean value
                    if (passActiveString == "True" || passActiveString == "False")
                    {
                        // Set the new active status
                        beverageToEdit.Active = (passActiveString == "True");

                    }
                    else
                    {
                        // The string did not represent a bollean value
                        return beverageEditedBool;

                    }

                }

                // Save changes to the beverage collection
                beverageContext.SaveChanges();

                // All data was updated
                beverageEditedBool = true;

            }

            //
            return beverageEditedBool;

        }

        /// <summary>
        /// Delete the passed in Beverage from the database
        /// </summary>
        /// <param name="passKey"> The key attribute of the Beverage to be deleted </param>
        /// <returns> The success state of the beverage being deleted </returns>
        public bool DeleteBeverage(string passKey)
        {
            // Try to find and get the beverage from the collection
            Beverage beverageToDelete = beverageContext.Beverages.Find(passKey);

            // Has the beverage been added?
            bool beverageDeletedBool = false;

            // Check that a beverage with the passed in key exists in the collection
            if (beverageToDelete != null)
            {
                // Remove the beverage from the collection
                beverageContext.Beverages.Remove(beverageToDelete);

                // Save changes to the beverage collection
                beverageContext.SaveChanges();

                // The beverage was deleted
                beverageDeletedBool = true;

            }

            // Return if the beverage was deleted
            return beverageDeletedBool;

        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through each beverage in the database
            foreach (Beverage beverage in beverageContext.Beverages)
            {
                // If the current beverage is not null, add it to the return string
                if (beverage != null)
                {
                    // Accumulate the current beverage to the return string
                    returnString += this.BeverageToString(beverage) + Environment.NewLine;

                }                

            }

            // Return the return string
            return returnString;
        }

        // Find an item by it's Id
        public string FindBeverageInformationById(string passId)
        {
            // Declare return string for the possible found item
            string returnString = null;

            // Get the beverage with the passed in Id or return null if not found
            Beverage beverage = beverageContext.Beverages.Find(passId);

            // Check that the beverage was found
            if (beverage != null)
            {
                // Format the beverage in string form
                returnString = BeverageToString(beverage);

            }            

            // Return the returnString
            return returnString;

        }

        /// <summary>
        /// Format a beverage into concatenated line of traits
        /// </summary>
        /// <param name="passBeverage"> Beverage with an Id, Name, Packing, Price, and Activity </param>
        /// <returns> Concatenated string </returns>
        private string BeverageToString(Beverage passBeverage)
        {
            // Concatenated string of Beverage data fields
            return passBeverage.Id.PadRight(9) +
                   passBeverage.Name +
                   passBeverage.Pack +
                   passBeverage.Price.ToString("c") + "  " +
                   passBeverage.Active.ToString() + Environment.NewLine;

        }

    }

}
