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
                double thisAmount = 0;

                thisAmount = amountFor(each);

                // Add frequent renters points.
                frequentRenterPoints++;

                // Add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) &&
                        each.DaysRented > 1)
                    frequentRenterPoints++;

                // Show figures for this rental.
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // Add footer lines.
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";
            return result;
        }

        // Method extracted, some parameters renamed.
        //private double amountFor(Rental each)
        private double amountFor(Rental aRental)
        {
            // Renamed
            //double thisAmount = 0;
            double result = 0;

            // Determine amounts for each line.
            switch (aRental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (aRental.DaysRented > 2)
                        result += (aRental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += aRental.DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (aRental.DaysRented > 3)
                        result += (aRental.DaysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}
