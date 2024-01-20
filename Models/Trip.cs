namespace BRTS.Web.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string TripGoingFrom { get; set; }

        public string TripDestination { get; set; }

        public DateTime StartDateAndTime { get; set; }

        public DateTime EndDateAndTime { get; set; }

        public string TripName { get; set; }
    }
}
