using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    // 2. Implement abstract class in order to use the 'State Pattern' for price codes.
    public class ChildrensPrice : Price
    {
        public override int PriceCode()
        {
            return Movie.CHILDRENS;
        }

        // 5. Implement 'Replace Conditional with Polymorphism' from Price class
        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}
