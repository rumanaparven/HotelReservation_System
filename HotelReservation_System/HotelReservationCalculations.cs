using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation_System
{
    public class HotelReservationCalculations
    {
        public enum CustomerType { Regular, Reward };
        //public static HotelReservation AddSampleHotels(HotelReservation hotelReservation)
        //{
        //    hotelReservation.AddHotelDetails(new Hotel { hotelName = "Lakewood", weekdayRatesForRegular = 110, weekendRatesForRegular = 90, weekdayRatesLoyalty = 80, weekendRatesLoyalty = 80, rating = 3 });
        //    hotelReservation.AddHotelDetails(new Hotel { hotelName = "Bridgewood", weekdayRatesForRegular = 150, weekendRatesForRegular = 50, weekdayRatesLoyalty = 110, weekendRatesLoyalty = 50, rating = 4 });
        //    hotelReservation.AddHotelDetails(new Hotel { hotelName = "Ridgewood", weekdayRatesForRegular = 220, weekendRatesForRegular = 150, weekdayRatesLoyalty = 100, weekendRatesLoyalty = 40, rating = 5 });

        //    return hotelReservation;

        //}
        //public static void FindCheapest(HotelReservation hotelReservation)
        //{
        //    Console.Write("Enter the date range : ");
        //    var input = Console.ReadLine();
        //    string[] dates = input.Split(',');
        //    try
        //    {
        //        var startDate = Convert.ToDateTime(dates[0]);
        //        var endDate = Convert.ToDateTime(dates[1]);
        //        var cheapestHotel = hotelReservation.FindCheapestHotels(startDate, endDate);
        //        foreach (Hotel h in cheapestHotel)
        //        {
        //            var cost = hotelReservation.CalculateCost(h, startDate, endDate);
        //            Console.WriteLine("Hotel : {0}, Total Cost : {1}", h.hotelName, cost);
        //        }
        //    }
        //    catch
        //    {
        //        Console.Write("Enter the correct date range \n");
        //        FindCheapest(hotelReservation);
        //    }
        //}
        //public static void FindCheapestBest(HotelReservation hotelReservation)
        //{
        //    Console.WriteLine("Cheapest Best Rated Hotel");
        //    Console.Write("Enter the date range : ");
        //    var input = Console.ReadLine();
        //    string[] dates = input.Split(',');
        //    try
        //    {
        //        var startDate = Convert.ToDateTime(dates[0]);
        //        var endDate = Convert.ToDateTime(dates[1]);
        //        var cheapestHotel = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);
        //        foreach (Hotel h in cheapestHotel)
        //        {
        //            var cost = hotelReservation.CalculateCost(h, startDate, endDate);
        //            Console.WriteLine("Hotel : {0}, Rating: {1}, Total Cost : {2}", h.hotelName, h.rating, cost);
        //        }
        //    }
        //    catch
        //    {
        //        Console.Write("Enter the correct date range \n");
        //        FindCheapest(hotelReservation);
        //    }
        //}
        //public static void FindBest(HotelReservation hotelReservation)
        //{
        //    Console.WriteLine("Cheapest Best Rated Hotel");
        //    Console.Write("Enter the date range : ");
        //    var input = Console.ReadLine();
        //    string[] dates = input.Split(',');
        //    try
        //    {
        //        var startDate = Convert.ToDateTime(dates[0]);
        //        var endDate = Convert.ToDateTime(dates[1]);
        //        var cheapestHotel = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);
        //        foreach (Hotel h in cheapestHotel)
        //        {
        //            var cost = hotelReservation.CalculateCost(h, startDate, endDate);
        //            Console.WriteLine("Hotel : {0}, Rating: {1}, Total Cost : {2}", h.hotelName, h.rating, cost);
        //        }
        //    }
        //    catch
        //    {
        //        Console.Write("Enter the correct date range \n");
        //        FindCheapest(hotelReservation);
        //    }
        //}
        public static CustomerType GetCustomerType(CustomerType customer)
        {
            Console.Write("Enter the type of Customer : ");
            var cusType = Console.ReadLine().ToLower();
            if (cusType != "regular" && cusType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            return cusType == "regular" ? CustomerType.Regular : CustomerType.Reward;
        }
    }
}
