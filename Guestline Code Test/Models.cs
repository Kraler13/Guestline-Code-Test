using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Guestline_Code_Test
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("roomTypes")]
        public List<RoomType> RoomTypes { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }
    }

    public class RoomType
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amenities")]
        public List<string> Amenities { get; set; }

        [JsonPropertyName("features")]
        public List<string> Features { get; set; }
    }

    public class Room
    {
        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }
    }

    public class Booking
    {
        [JsonPropertyName("hotelId")]
        public string HotelId { get; set; }

        [JsonPropertyName("arrival")]
        public string Arrival { get; set; }

        [JsonPropertyName("departure")]
        public string Departure { get; set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("roomRate")]
        public string RoomRate { get; set; }
    }
}
