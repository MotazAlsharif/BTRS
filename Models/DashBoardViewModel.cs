namespace BRTS.Web.Models
{
    public class DashBoardViewModel
    {
        public DashBoardViewModel(List<Account> _accounts, List<Bus> _buses, List<Trip> _trips)
        {
            accounts = _accounts;
            buses = _buses;
            trips = _trips;
        }
        public DashBoardViewModel( List<Trip> _trips, int _id, List<Trip> _bookedTrips)
        {
            id = _id;
            trips = _trips;
            bookedTrips = _bookedTrips;
        }
        public int id { get; set; }
        public List<Account> accounts { get; set; }
        public List<Bus> buses { get; set; }
        public List<Trip> trips { get; set; }
        public List<Trip> bookedTrips { get; set; }
    }
}
