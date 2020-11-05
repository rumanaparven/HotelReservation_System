using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation_System
{
    public class HotelReservation
    {
        public Dictionary<string, Hotel> hotelDetails;

        public HotelReservation()
        {
            hotelDetails = new Dictionary<string, Hotel>();
        }

        public void AddHotelDetails(Hotel hotel)
        {
            if (hotelDetails.ContainsKey(hotel.hotelName))
            {
                Console.WriteLine("Hotel already exists..!!");

            }

            hotelDetails.Add(hotel.hotelName, hotel);
        }
        public int GetRating(string hotelName)
        {
            foreach(var hotel in hotelDetails)
            {
                if (hotel.Key.Equals(hotelName))
                {
                    return hotel.Value.rating;
                }
                
            }
            return 0;
        }
        public int GetRatesForRewardCustomers(string hotelName)
        {
            foreach (var hotel in hotelDetails)
            {
                if (hotel.Key.Equals(hotelName))
                {
                    return hotel.Value.weekdayRatesLoyalty;
                }

            }
            return 0;
        }
       
        public int CalculateCost(Hotel hotel, DateTime startDate, DateTime endDate)
        {
            var cost = 0;
            var weekdayRate = hotel.weekdayRatesForRegular;
            var weekendRate = hotel.weekendRatesForRegular;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    cost += weekendRate;
                else
                    cost += weekdayRate;
            }
            return cost;
        }
        public Hotel FindCheapestHotel(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("Error! StartDate greater than EndDate");
            }

            var cost = Int32.MaxValue;
            Hotel lowBudgetHotel = new Hotel();
            foreach (var hotel in hotelDetails)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateCost(hotel.Value, startDate, endDate));
                if (temp != cost)
                    lowBudgetHotel = hotel.Value;
            }
            return lowBudgetHotel;
        }
        public List<Hotel> FindCheapestHotels(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date");
                return null;
            }
            var cost = Int32.MaxValue;
            var cheapestHotels = new List<Hotel>();
            foreach (var hotel in hotelDetails)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateCost(hotel.Value, startDate, endDate));

            }
            foreach (var hotel in hotelDetails)
            {
                if (CalculateCost(hotel.Value, startDate, endDate) == cost)
                    cheapestHotels.Add(hotel.Value);
            }
            return cheapestHotels;
        }
        public List<Hotel> FindBestHotels(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date");
                return null;
            }
            var cost = 0;
            var BestHotels = new List<Hotel>();
            foreach (var hotel in hotelDetails)
            {
                
                cost = Math.Max(cost, CalculateCost(hotel.Value, startDate, endDate));

            }
            foreach (var hotel in hotelDetails)
            {
                if (CalculateCost(hotel.Value, startDate, endDate) == cost)
                    BestHotels.Add(hotel.Value);
            }
            return BestHotels;
        }

        public List<Hotel> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            var cheapestHotels = FindCheapestHotels(startDate, endDate);
            List<Hotel> cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in cheapestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in cheapestHotels)
                if (hotel.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel);
            return cheapestBestRatedHotels;
        }

        public List<Hotel> FindBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            var BestHotels = FindBestHotels(startDate, endDate);
            List<Hotel> BestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in BestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in BestHotels)
                if (hotel.rating == maxRating)
                    BestRatedHotels.Add(hotel);
            return BestRatedHotels;
        }
    }
}
