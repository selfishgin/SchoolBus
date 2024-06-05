using System;

namespace SchoolBusManagement.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int BusId { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
    }
}
