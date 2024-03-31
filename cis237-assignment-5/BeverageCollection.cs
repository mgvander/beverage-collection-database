/// Author: Michael VanderMyde
/// Course: CIS-237
/// Assignment 5

using cis237_assignment_5.Models;
using System;

namespace cis237_assignment_5
{
    class BeverageCollection
    {
        // Private Variables
        //private Beverage[] beverages;
        //private int beverageLength;

        private BeverageContext beverageContext = new BeverageContext();

        //// Constructor. Must pass the size of the collection.
        //public BeverageCollection(int size)
        //{
        //    this.beverages = new Beverage[size];
        //    this.beverageLength = 0;
        //}

        // Add a new item to the collection
        // Return the success status of the beverage addition
        public bool AddNewBeverage(string passId,
                                   string passName,
                                   string passPack,
                                   decimal passPrice,
                                   bool passActive)
        {
            // Add a new Beverage to the collection. Increase the Length variable.
            //beverages[beverageLength] = new Beverage(id, name, pack, price, active);
            //beverageLength++;

            // Make a new instance of a beverage
            Beverage newBeverage = new Beverage();

            // Has the beverage been added?
            bool beverageAddedBool = false;

            // Set Id, name, packing, price, and activity
            newBeverage.Id = passId;
            newBeverage.Name = passName;
            newBeverage.Pack = passPack;
            newBeverage.Price = passPrice;
            newBeverage.Active = passActive;

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

            //// Loop through all of the beverages
            //foreach (Beverage beverage in beverages)
            //{
            //    // If the current beverage is not null, concat it to the return string
            //    if (beverage != null)
            //    {
            //        returnString += beverage.ToString() + Environment.NewLine;
            //    }
            //}

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
        public string FindById(string passId)
        {
            // Declare return string for the possible found item
            string returnString = null;

            //// For each Beverage in beverages
            //foreach (Beverage beverage in beverages)
            //{
            //    // If the beverage is not null
            //    if (beverage != null)
            //    {
            //        // If the beverage Id is the same as the search Id
            //        if (beverage.Id == id)
            //        {
            //            // Set the return string to the result
            //            // of the beverage's ToString method.
            //            returnString = beverage.ToString();
            //        }
            //    }
            //}

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
            // Concatenate the data points of a beverage into a line
            //return passBeverage.Id.PadRight(9) + 
            //       passBeverage.Name.PadRight(57) + 
            //       passBeverage.Pack.PadRight(18) + 
            //       passBeverage.Price.ToString("c").PadLeft(7) + 
            //       passBeverage.Active.ToString().PadRight(6) + Environment.NewLine;

            return passBeverage.Id.PadRight(9) +
                   passBeverage.Name +
                   passBeverage.Pack +
                   passBeverage.Price.ToString("c") + "  " +
                   passBeverage.Active.ToString() + Environment.NewLine;

        }

    }

}
