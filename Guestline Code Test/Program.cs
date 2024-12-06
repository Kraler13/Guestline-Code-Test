namespace Guestline_Code_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hotels = DataLoader.LoadHotels("hotels.json");
            var bookings = DataLoader.LoadBookings("bookings.json");

            Console.WriteLine("Welcome to the Hotel Room Availability Checker!");
            while (true)
            {
                Console.WriteLine("Example: Availability(H1, 2024-09-01, SGL) or Availability(H1, 2024-09-01-2024-09-03, DBL)");
                Console.WriteLine("Leave empty to exit.");

                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                try
                {
                    if (!input.StartsWith("Availability(") || !input.EndsWith(")"))
                    {
                        Console.WriteLine("Invalid input format. Query must start with 'Availability(' and end with ')'.");
                        continue;
                    }

                    var parts = input.Replace("Availability(", "").Replace(")", "").Split(',');
                    if (parts.Length != 3)
                    {
                        Console.WriteLine("Invalid input format. Make sure to include HOTEL_ID, DATE_RANGE, and ROOM_TYPE.");
                        continue;
                    }

                    string hotelId = parts[0].Trim();
                    string dateRange = parts[1].Trim();
                    string roomType = parts[2].Trim();

                    Console.WriteLine($"Input Date Range: {dateRange}");

                    int availability = AvailabilityChecker.CheckAvailability(
                                hotels, bookings, hotelId, dateRange, roomType);

                    Console.WriteLine($"Available rooms for {roomType} in hotel {hotelId}: {availability}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid date format: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}