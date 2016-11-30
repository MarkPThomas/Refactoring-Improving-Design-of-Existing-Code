using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public string Title { get; private set; }
        public int PriceCode { get; set; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        // 1. Extract and Move method here from 'Rental', since:
        // - it uses a switch statement on the 'Movie' data.
        // - it uses Movie types, and type information tends to be more volatile, so better to keep this in the Movie class and pass in DaysRented.
        public double GetCharge(int daysRented)
        {
            double result = 0;

            switch (PriceCode)
            {
                case REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
        }

        // 2. Extract and Move method here from 'Rental' to isolate the effects of potentially changing Movie types.
        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((PriceCode == NEW_RELEASE) &&
                daysRented > 1)
                return 2;
            else
                return 1;
        }
    }
}
