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
        private Price _price;
        public int PriceCode
        {
            get
            {
                return _price.PriceCode();
            }
            private set
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
        
        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}
