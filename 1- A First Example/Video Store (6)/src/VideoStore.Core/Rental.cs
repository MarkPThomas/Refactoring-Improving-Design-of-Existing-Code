using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    /// <summary>
    /// Represents a customer renting a movie.
    /// </summary>
    public class Rental
    {
        public Movie Movie { get; private set; }
        public int DaysRented { get; private set; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public double GetCharge()
        {
            double result = 0;

            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += DaysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5;
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            if ((Movie.PriceCode == Movie.NEW_RELEASE) &&
                DaysRented > 1)
                return 2;
            else
                return 1;
        }
    }
}
