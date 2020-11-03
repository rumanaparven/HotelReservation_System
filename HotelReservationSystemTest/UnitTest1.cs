using HotelReservation_System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;

namespace HotelReservationSystemTest
{
    public class Tests
    {
        HotelReservation hotelReservation = new HotelReservation();


        [Test]
        public void UC1_Add_Hotel_With_name_and_rates_for_regular_customer()
        {

            var hotel1 = new Hotel { hotelName = "Lakewood", weekdayRatesForRegular = 110, weekendRatesForRegular = 120 };
            var hotel2 = new Hotel { hotelName = "Bridgewood", weekdayRatesForRegular = 150, weekendRatesForRegular = 180 };
            var hotel3 = new Hotel { hotelName = "Ridgewood", weekdayRatesForRegular = 210, weekendRatesForRegular = 250 };
            var count = hotelReservation.hotelDetails.Count;
            hotelReservation.AddHotelDetails(hotel1);
            hotelReservation.AddHotelDetails(hotel2);
            hotelReservation.AddHotelDetails(hotel3);
            int newCount = hotelReservation.hotelDetails.Count;
            int expected = count + 3;
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
        public void UC3_Check_For_Weekday_And_Weekend_Rates()
        {
            var startDate = Convert.ToDateTime("11June2020");
            var endDate = Convert.ToDateTime("12June2020");
            Hotel cheapestHotel = hotelReservation.FindCheapestHotel(startDate, endDate);
            var expected = hotelReservation.hotelDetails["Lakewood"];
            Assert.AreEqual(expected, cheapestHotel);

        }
        [Test]
        public void UC4_FindCheapestHotels_BasedOnWeekdayAndWeekend()
        {
            var startDate = Convert.ToDateTime("10Sep2020");
            var endDate = Convert.ToDateTime("11Sep2020");

            //hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotelDetails["Lakewood"];
            var result = hotelReservation.FindCheapestHotels(startDate, endDate);
            Assert.AreEqual(expected, result);

        }
    }
}