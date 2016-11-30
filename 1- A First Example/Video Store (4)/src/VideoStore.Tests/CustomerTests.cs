using System;
using System.Collections.Generic;

using NUnit.Framework;

using VideoStore.Core;

namespace VideoStore.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void statement_with_0_movies()
        {
            string customerName = "Frank";
            Customer customer = new Customer(customerName);

            string expected = string.Format("Rental Record for {0}\n" +
                                            "Amount owed is {1}\n" +
                                            "You earned {2} frequent renter points",
                                            customerName, 0, 0, string.Empty, 0);

            Assert.AreEqual(expected, customer.Statement());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void statement_with_1_childrens_movie(int daysRented)
        {
            string customerName = "Frank";
            Customer customer = new Customer(customerName);
            string expected = $"Rental Record for {customerName}\n";

            double totalAmount = 0;
            addRentals_childrens_movie(1, daysRented, ref customer, ref expected, ref totalAmount);

            int frequentRenterPoints = 1;

            expected += $"Amount owed is {totalAmount}\n" + $"You earned {frequentRenterPoints} frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void statement_with_1_newRelease_movie(int daysRented)
        {
            string customerName = "Frank";
            Customer customer = new Customer(customerName);
            string expected = $"Rental Record for {customerName}\n";

            double totalAmount = 0;
            addRentals_newRelease_movie(1, daysRented, ref customer, ref expected, ref totalAmount);

            int frequentRenterPoints = 1;
            if (daysRented > 1)
                frequentRenterPoints++;

            expected += $"Amount owed is {totalAmount}\n" + $"You earned {frequentRenterPoints} frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void statement_with_1_regular_movie_(int daysRented)
        {
            string customerName = "Frank";
            Customer customer = new Customer(customerName);
            string expected = $"Rental Record for {customerName}\n";

            double totalAmount = 0;
            addRentals_regular_movie(1, daysRented, ref customer, ref expected, ref totalAmount);

            int frequentRenterPoints = 1;

            expected += $"Amount owed is {totalAmount}\n" + $"You earned {frequentRenterPoints} frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void statement_with_3_childrens_movie_2_regular_movie_3_newRelease_movies(int daysRented)
        {
            string customerName = "Frank";
            Customer customer = new Customer(customerName);
            string expected = $"Rental Record for {customerName}\n";

            double totalAmount = 0;
            addRentals_3_childrens_movie_3_regular_movie_2_newRelease_movie(daysRented, ref customer, ref expected, ref totalAmount);

            int frequentRenterPoints = 8;
            if (daysRented > 1)
                frequentRenterPoints += 3;

            expected += $"Amount owed is {totalAmount}\n" + $"You earned {frequentRenterPoints} frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }


        

        private void addRentals_3_childrens_movie_3_regular_movie_2_newRelease_movie(
           int daysRented,
           ref Customer customer,
           ref string expected,
           ref double totalAmount)
        {
            addRentals_childrens_movie(3, daysRented, ref customer, ref expected, ref totalAmount);
            addRentals_regular_movie(2, daysRented, ref customer, ref expected, ref totalAmount);
            addRentals_newRelease_movie(3, daysRented, ref customer, ref expected, ref totalAmount);
        }

        private void addRentals_childrens_movie(
            int numberOfMovies,
            int daysRented,
            ref Customer customer,
            ref string expected,
            ref double totalAmount)
        {
            double thisAmount;

           if (numberOfMovies > 0)
            {
                Movie snowWhite = new Movie("Snow White", Movie.CHILDRENS);
                customer.AddRental(new Rental(snowWhite, daysRented));
                thisAmount = thisAmountChildrens(daysRented);
                totalAmount += thisAmount;
                expected += $"\t{snowWhite.Title}\t{thisAmount}\n";
            }
           if (numberOfMovies > 1)
            {
                Movie aladdin = new Movie("Aladdin", Movie.CHILDRENS);
                customer.AddRental(new Rental(aladdin, daysRented));
                thisAmount = thisAmountChildrens(daysRented);
                totalAmount += thisAmount;
                expected += $"\t{aladdin.Title}\t{thisAmount}\n";
            }
           if (numberOfMovies > 2)
            {
                Movie spongeBob = new Movie("Sponge Bob Square Pants", Movie.CHILDRENS);
                customer.AddRental(new Rental(spongeBob, daysRented));
                thisAmount = thisAmountChildrens(daysRented);
                totalAmount += thisAmount;
                expected += $"\t{spongeBob.Title}\t{thisAmount}\n";
            }
        }

        private void addRentals_regular_movie(
           int numberOfMovies,
           int daysRented,
           ref Customer customer,
           ref string expected,
           ref double totalAmount)
        {
            double thisAmount;

        if (numberOfMovies > 0)
        {
            Movie apollo13 = new Movie("Apollo 13", Movie.REGULAR);
            customer.AddRental(new Rental(apollo13, daysRented));
            thisAmount = thisAmountRegular(daysRented);
            totalAmount += thisAmount;
            expected += $"\t{apollo13.Title}\t{thisAmount}\n";
        }
        if (numberOfMovies > 1)
        {
            Movie apocalypseNow = new Movie("Apocalypse Now", Movie.REGULAR);
            customer.AddRental(new Rental(apocalypseNow, daysRented));
            thisAmount = thisAmountRegular(daysRented);
            totalAmount += thisAmount;
            expected += $"\t{apocalypseNow.Title}\t{thisAmount}\n";
        }
    }

        private void addRentals_newRelease_movie(
           int numberOfMovies,
           int daysRented,
           ref Customer customer,
           ref string expected,
           ref double totalAmount)
        {
            double thisAmount;

        if (numberOfMovies > 0)
        {
            Movie dieHard12 = new Movie("Die Hard 12: I'm Not Dead Yet!", Movie.NEW_RELEASE);
            customer.AddRental(new Rental(dieHard12, daysRented));
            thisAmount = thisAmountNewRelease(daysRented);
            totalAmount += thisAmount;
            expected += $"\t{dieHard12.Title}\t{thisAmount}\n";
         }
        if (numberOfMovies > 1)
        {
            Movie phantomShark = new Movie("Phantom Shark", Movie.NEW_RELEASE);
            customer.AddRental(new Rental(phantomShark, daysRented));
            thisAmount = thisAmountNewRelease(daysRented);
            totalAmount += thisAmount;
            expected += $"\t{phantomShark.Title}\t{thisAmount}\n";
        }
        if (numberOfMovies > 2)
        {
            Movie youveGotMail = new Movie("You've Got Mail", Movie.NEW_RELEASE);
            customer.AddRental(new Rental(youveGotMail, daysRented));
            thisAmount = thisAmountNewRelease(daysRented);
            totalAmount += thisAmount;
            expected += $"\t{youveGotMail.Title}\t{thisAmount}\n";
        }
    }

        private double thisAmountChildrens(int daysRented)
        {
            double thisAmount = 1.5;

            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }

            return thisAmount;
        }

        private double thisAmountRegular(int daysRented)
        {
            double thisAmount = 2;

            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5;
            }

            return thisAmount;
        }

        private double thisAmountNewRelease(int daysRented)
        {
            double thisAmount = daysRented*3;
            
            return thisAmount;
        }
    }
}
