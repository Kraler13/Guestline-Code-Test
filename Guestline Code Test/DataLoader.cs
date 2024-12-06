using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Guestline_Code_Test
{
    internal class DataLoader
    {
        public static List<Hotel> LoadHotels(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var hotels = JsonSerializer.Deserialize<List<Hotel>>(json) ?? new List<Hotel>();
                Console.WriteLine($"Loaded {hotels.Count} hotels.");
                foreach (var hotel in hotels)
                {
                    Console.WriteLine($"Hotel ID: {hotel.Id}, Name: {hotel.Name}");
                    foreach (var room in hotel.Rooms)
                    {
                        Console.WriteLine($"Room ID: {room.RoomId}, Room Type: {room.RoomType}");
                    }
                }
                return hotels;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading hotels: {ex.Message}");
                return new List<Hotel>();
            }
        }

        public static List<Booking> LoadBookings(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var bookings = JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
                Console.WriteLine($"Loaded {bookings.Count} bookings.");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"HotelId: {booking.HotelId}, RoomType: {booking.RoomType}, Arrival: {booking.Arrival}, Departure: {booking.Departure}");
                }
                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading bookings: {ex.Message}");
                return new List<Booking>();
            }
        }
    }
}
