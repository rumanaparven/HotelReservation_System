using HotelReservation_System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotelReservationSystemTest
{
    public class Tests
    {
        HotelReservation hotelReservation = new HotelReservation();
        private object list;

        [Test]
        public void UC1_Add_Hotel_With_name_and_rates_for_regular_customer()
        {

            hotelReservation.AddHotelDetails(new Hotel { hotelName = "Lakewood", weekdayRatesForRegular = 110, weekendRatesForRegular = 90, weekdayRatesLoyalty = 80, weekendRatesLoyalty = 80, rating = 3 });
            hotelReservation.AddHotelDetails(new Hotel { hotelName = "Bridgewood", weekdayRatesForRegular = 150, weekendRatesForRegular = 50, weekdayRatesLoyalty = 110, weekendRatesLoyalty = 50, rating = 4 });
            hotelReservation.AddHotelDetails(new Hotel { hotelName = "Ridgewood", weekdayRatesForRegular = 220, weekendRatesForRegular = 150, weekdayRatesLoyalty = 100, weekendRatesLoyalty = 40, rating = 5 });

            var count = hotelReservation.hotelDetails.Count;
            //hotelReservation.AddHotelDetails(hotel1);
            //hotelReservation.AddHotelDetails(hotel2);
            //hotelReservation.AddHotelDetails(hotel3);
            int newCount = hotelReservation.hotelDetails.Count;
            int expected = 3;
            Assert.AreEqual(expected, newCount);

        }
        [Test]
        public void UC2_Find_Cheapest_Hotel()
        {
            var startDate = Convert.ToDateTime("12May2020");
            var endDate = Convert.ToDateTime("14May2020");
            Hotel cheapestHotel = hotelReservation.FindCheapestHotel(startDate, endDate);
            var expected = hotelReservation.hotelDetails["Lakewood"];
            Assert.AreEqual(expected, cheapestHotel);

        }

        [Test]
        public void UC4_Check_For_Weekday_And_Weekend_Rates()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");
            List<Hotel> hotelList= hotelReservation.FindCheapestHotels(startDate, endDate);
            var expected1 = "Lakewood";
            var expected2 = "Bridgewood";
            Assert.AreEqual(expected1, hotelList[0].hotelName);
            Assert.AreEqual(expected2, hotelList[1].hotelName);

        }
        [Test]
        public void UC5_AddRatings()
        {
            int rating = hotelReservation.GetRating("Ridgewood");
            int expected = 5;
            Assert.AreEqual(expected, rating);
        }
        [Test]
        public void UC6_CheckForCheapestBestRatedHotel()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");
            List<Hotel> list = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);
            var expected1 = "Bridgewood";
            Assert.AreEqual(expected1, list[0].hotelName);
          

        }
        [Test]
        public void UC7_FindTheBestRatedHoted()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");
            List<Hotel> list = hotelReservation.FindBestRatedHotel(startDate, endDate);
            var expected1 = "Ridgewood";
            Assert.AreEqual(expected1, list[list.Count-1].hotelName);
        }
        [Test]
        public void UC9_CheckForSpecialRatesForRewardCustomer()
        {
            int weekdayRate = hotelReservation.GetRatesForRewardCustomers("Lakewood");
            int expected = 80;
            Assert.AreEqual(expected, weekdayRate);
            
        }


    }
}