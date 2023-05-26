namespace VacationRentalSWEProject.Model
{
    public class UserDestination
    {
        public int UserID { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Hidden from the API
        public User? User { get; set; } = null!;
        public Destination? Destination { get; set; } = null!;
    }
}

