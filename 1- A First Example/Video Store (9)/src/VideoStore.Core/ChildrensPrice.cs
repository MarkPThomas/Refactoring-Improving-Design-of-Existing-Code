﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Core
{
    public class ChildrensPrice : Price
    {
        public override int PriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}
