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
                // 2. Change counting method such that it does not need to be passed into the new method as a parameter.
                // Add frequent renters points.
                //frequentRenterPoints++;
                frequentRenterPoints += each.GetFrequentRenterPoints();

                //// 1. Use Extract Method & Move Method to move this method to the Rental class.
                //// Add bonus for a two day new release rental
                //if ((each.Movie.PriceCode == Movie.NEW_RELEASE) &&
                //        each.DaysRented > 1)
                //    frequentRenterPoints++;

                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
                totalAmount += each.GetCharge();
            }

            // Add footer lines.
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
