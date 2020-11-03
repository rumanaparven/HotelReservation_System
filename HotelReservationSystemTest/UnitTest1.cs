using HotelReservation_System;
using NUnit.Framework;

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
    }
}