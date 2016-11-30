using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    // 2. Implement abstract class in order to use the 'State Pattern' for price codes.
    public class NewReleasePrice : Price
    {
        public override int PriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        // 5. Implement 'Replace Conditional with Polymorphism' from Price class
        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        // 8. Implement 'Replace Conditional with Polymorphism' from Price class
        public override int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
}
