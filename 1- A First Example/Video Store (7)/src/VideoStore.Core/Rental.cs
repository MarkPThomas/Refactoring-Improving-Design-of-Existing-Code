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

        // 1. Extract and Move method here to 'Movie', since:
        // - it uses a switch statement on the 'Movie' data.
        // - it uses Movie types, and type information tends to be more volatile, so better to keep this in the Movie class and pass in DaysRented.
        public double GetCharge()
        {
            return Movie.GetCharge(DaysRented);
        }

        // 2. Extract and Move method here to 'Movie' to isolate the effects of potentially changing Movie types.
        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(DaysRented);
        }
    }
}
