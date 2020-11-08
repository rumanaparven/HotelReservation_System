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
       
        public int CalculateCost(Hotel hotel, DateTime startDate, DateTime endDate,CustomerType customerType)
        {
            var cost = 0;
            var weekdayRate = customerType == CustomerType.Regular ? hotel.weekdayRatesForRegular : hotel.weekdayRatesLoyalty;
            var weekendRate = customerType == CustomerType.Regular ? hotel.weekendRatesForRegular : hotel.weekendRatesLoyalty;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    cost += weekendRate;
                else
                    cost += weekdayRate;
            }
            return cost;
        }
        public Hotel FindCheapestHotel(DateTime startDate, DateTime endDate,CustomerType customerType)
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
                cost = Math.Min(cost, CalculateCost(hotel.Value, startDate, endDate,customerType));
                if (temp != cost)
                    lowBudgetHotel = hotel.Value;
            }
            return lowBudgetHotel;
        }
        public List<Hotel> FindCheapestHotels(DateTime startDate, DateTime endDate,CustomerType customerType)
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
                cost = Math.Min(cost, CalculateCost(hotel.Value, startDate, endDate,customerType));

            }
            foreach (var hotel in hotelDetails)
            {
                if (CalculateCost(hotel.Value, startDate, endDate,customerType) == cost)
                    cheapestHotels.Add(hotel.Value);
            }
            return cheapestHotels;
        }
        public List<Hotel> FindBestHotels(DateTime startDate, DateTime endDate,CustomerType customerType)
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
                
                cost = Math.Max(cost, CalculateCost(hotel.Value, startDate, endDate,customerType));

            }
            foreach (var hotel in hotelDetails)
            {
                if (CalculateCost(hotel.Value, startDate, endDate,customerType) == cost)
                    BestHotels.Add(hotel.Value);
            }
            return BestHotels;
        }

        public List<Hotel> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate,CustomerType customerType)
        {
            var cheapestHotels = FindCheapestHotels(startDate, endDate,customerType);
            List<Hotel> cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in cheapestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in cheapestHotels)
                if (hotel.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel);
            return cheapestBestRatedHotels;
        }

        public List<Hotel> FindBestRatedHotel(DateTime startDate, DateTime endDate, CustomerType customerType)
        {
            var BestHotels = FindBestHotels(startDate, endDate, customerType);
            List<Hotel> BestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in BestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in BestHotels)
                if (hotel.rating == maxRating)
                    BestRatedHotels.Add(hotel);
            return BestRatedHotels;
        }
        public enum CustomerType { Regular, Reward };
        public static CustomerType GetCustomerType()
        {
            var cusType = "ordinary";
            if (cusType != "regular" && cusType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            return cusType == "regular" ? CustomerType.Regular : CustomerType.Reward;
        }

    }
}
