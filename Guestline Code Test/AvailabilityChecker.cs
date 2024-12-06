using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Guestline_Code_Test
{
    internal class AvailabilityChecker
    {
        public static int CheckAvailability(
           List<Hotel> hotels,
           List<Booking> bookings,
           string hotelId,
           string dateRange,
           string roomType)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null) return 0;

            int totalRooms = hotel.Rooms.Count(r => r.RoomType == roomType);

            var dates = dateRange.Split('-');
            DateTime startDate = ParseDate(dates[0].Trim());
            DateTime endDate = dates.Length > 1 ? ParseDate(dates[1].Trim()) : startDate.AddDays(1);

            int bookedRooms = bookings
                .Where(b => b.HotelId == hotelId && b.RoomType == roomType)
                .Count(b => IsDateRangeOverlapping(startDate, endDate, b.Arrival, b.Departure));

            return totalRooms - bookedRooms;
        }

        private static bool IsDateRangeOverlapping(DateTime startDate, DateTime endDate, string arrival, string departure)
        {
            DateTime arrivalDate = ParseDate(arrival);
            DateTime departureDate = ParseDate(departure);

            return startDate < departureDate && endDate > arrivalDate;
        }

        private static DateTime ParseDate(string date)
        {
            string[] formats = { "yyyyMMdd", "yyyy-MM-dd", "dd/MM/yyyy" };
            if (DateTime.TryParseExact(date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            }
            throw new FormatException($"Invalid date format: {date}. Please use 'yyyyMMdd', 'yyyy-MM-dd', or 'dd/MM/yyyy'.");
        }
    }
}