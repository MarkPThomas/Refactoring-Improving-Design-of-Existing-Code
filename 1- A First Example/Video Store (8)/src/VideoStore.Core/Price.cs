using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    // 1. Create abstract class in order to use the 'State Pattern' for price codes.
    public abstract class Price
    {
        public abstract int PriceCode();

        // 6. Finish implementing 'Replace Conditional with Polymorphism' from Price class
        //// 4. Apply Move Method for method from Movie into Price
        //public virtual double GetCharge(int daysRented)
        //{
        //    double result = 0;

        //    switch (PriceCode())
        //    {
        //        case Movie.REGULAR:
        //            result += 2;
        //            if (daysRented > 2)
        //                result += (daysRented - 2) * 1.5;
        //            break;
        //        case Movie.NEW_RELEASE:
        //            result += daysRented * 3;
        //            break;
        //        case Movie.CHILDRENS:
        //            result += 1.5;
        //            if (daysRented > 3)
        //                result += (daysRented - 3) * 1.5;
        //            break;
        //    }

        //    return result;
        //}
        public abstract double GetCharge(int daysRented);

        // 8. Finish implementing 'Replace Conditional with Polymorphism' from Price class
        //// 7. Apply Move Method for method from Movie into Price
        //public virtual int GetFrequentRenterPoints(int daysRented)
        //{
        //    if ((PriceCode() == Movie.NEW_RELEASE) &&
        //        daysRented > 1)
        //        return 2;
        //    else
        //        return 1;
        //}
        public virtual int GetFrequentRenterPoints(int daysRented)
        {
          return 1;
        }
    }
}
