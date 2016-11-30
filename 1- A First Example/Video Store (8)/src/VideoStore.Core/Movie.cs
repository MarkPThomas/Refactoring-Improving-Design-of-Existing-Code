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
        // 3. Change accessors to implement the new 'State Pattern' classes.
        private Price _price;
        public int PriceCode
        {
            get
            {
                return _price.PriceCode();
            }
            set
            {
                switch (value)
                {
                    case REGULAR:
                        _price = new RegularPrice();
                        break;
                    case CHILDRENS:
                        _price = new ChildrensPrice();
                        break;
                    case NEW_RELEASE:
                        _price = new NewReleasePrice();
                        break;  
                    default:
                        throw new ArgumentException("Incorrect Price Code");
                }
            }
        }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        // 4. Apply Move Method for method from Movie into Price
        public double GetCharge(int daysRented)
        {
            //double result = 0;

            //switch (PriceCode)
            //{
            //    case REGULAR:
            //        result += 2;
            //        if (daysRented > 2)
            //            result += (daysRented - 2) * 1.5;
            //        break;
            //    case NEW_RELEASE:
            //        result += daysRented * 3;
            //        break;
            //    case CHILDRENS:
            //        result += 1.5;
            //        if (daysRented > 3)
            //            result += (daysRented - 3) * 1.5;
            //        break;
            //}

            //return result;
            return _price.GetCharge(daysRented);
        }

        // 7. Apply Move Method for method from Movie into Price
        public int GetFrequentRenterPoints(int daysRented)
        {
            //if ((PriceCode == NEW_RELEASE) &&
            //    daysRented > 1)
            //    return 2;
            //else
            //    return 1;
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}
