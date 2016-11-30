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
            //double totalAmount = 0;
            //int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (Rental each in _rentals)
            {
                //frequentRenterPoints += each.GetFrequentRenterPoints();

                // Show figures for this rental.
                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
                //totalAmount += each.GetCharge();
            }

            // Add footer lines.
            //result += "Amount owed is " + totalAmount + "\n";
            result += "Amount owed is " + GetTotalCharge() + "\n";
            //result += "You earned " + frequentRenterPoints + " frequent renter points";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";
            return result;
        }

        // 1: Extract Method to lead to Replace Temp with Query for temp variable 'totalAmount'.
        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental each in _rentals)
            {
                result += each.GetCharge();
            }

            return result;
        }

        // 2: Extract Method to lead to Replace Temp with Query for temp variable 'frequentRenterPoints'.
        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;

            foreach (Rental each in _rentals)
            {
                result += each.GetFrequentRenterPoints();
            }

            return result;
        }
    }
}
