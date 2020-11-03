﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation_System
{
    public enum ExceptionType { INVALID_CUSTOMER_TYPE };

    public class HotelReservationException : Exception
    {
        public ExceptionType exceptionType;
        public HotelReservationException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
