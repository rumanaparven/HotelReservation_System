﻿using System;

namespace HotelReservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");

            var hotelReservation = new HotelReservation();
            bool val = true;
            //Console.WriteLine("How many hotels do you want?");
            //int n = Convert.ToInt32(Console.ReadLine());
            while (val)
            {
                var hotel = new Hotel();
                Console.Write("Enter Hotel Name : ");
                hotel.hotelName = Console.ReadLine();

                Console.Write("Enter Regular Weekday Rate : ");
                hotel.weekdayRatesForRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Regular Weekend Rate : ");
                hotel.weekendRatesForRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Hotel Rating (5 being best, 1 being worst) : ");
                hotel.weekendRatesForRegular = Convert.ToInt32(Console.ReadLine());

                hotelReservation.AddHotelDetails(hotel);

                Console.WriteLine("Wanna add more hotels?(yes/no)");
                if (Console.ReadLine() == "no")
                    val = false;
            }
            FindCheapest(hotelReservation);


        }
        public static void FindCheapest(HotelReservation hotelReservation)
        {
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            try
            {
                var startDate = Convert.ToDateTime(dates[0]);
                var endDate = Convert.ToDateTime(dates[1]);
                var cheapestHotel = hotelReservation.FindCheapestHotels(startDate, endDate);
                foreach (Hotel h in cheapestHotel)
                {
                    var cost = hotelReservation.CalculateCost(h, startDate, endDate);
                    Console.WriteLine("Hotel : {0}, Total Cost : {1}", h.hotelName, cost);
                }
            }
            catch
            {
                Console.Write("Enter the correct date range \n");
                FindCheapest(hotelReservation);
            }
        }
    }
}
