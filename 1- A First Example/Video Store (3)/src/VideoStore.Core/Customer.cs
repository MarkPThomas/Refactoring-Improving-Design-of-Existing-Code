using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    /// <summary>
    /// Represents a customer of the store.
    /// </summary>
    public class Customer
    {
        public string Name { get; private set; }

        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (Rental each in _rentals)
            {
                // Step 6: Replace thisAmount with direct calls to the other class & new method to reduce the number of temp variables.
                // Replace Temp with Query method
                //double thisAmount = 0;

                // Step 6: Replace thisAmount with direct calls to the other class & new method to reduce the number of temp variables.
                // Replace Temp with Query method
                //// Step 4
                //// Redirect the method call from the local method to the new method in the other class
                ////thisAmount = amountFor(each);
                //thisAmount = each.GetCharge();

                // Add frequent renters points.
                frequentRenterPoints++;

                // Add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) &&
                        each.DaysRented > 1)
                    frequentRenterPoints++;

                // Step 6: Replace thisAmount with direct calls to the other class & new method to reduce the number of temp variables.
                // Replace Temp with Query method
                // Show figures for this rental.
                //result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                //totalAmount += thisAmount;
                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
                totalAmount += each.GetCharge();
            }

            // Add footer lines.
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        // Step 5
        // Remove method after redirect if it was not part of the original class public interface.
        //// Step 3
        //// The repeated use of data in the Rental type indicated that 'Move Method' should be done to move the method to the class where the data 'lives'.
        //// So the method was moved from here to 'Rental'.
        //private double amountFor(Rental aRental)
        //{
        //    return aRental.GetCharge();
        //}
    }
}
