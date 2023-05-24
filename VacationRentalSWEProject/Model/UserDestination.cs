namespace VacationRentalSWEProject.Model
{
    public class UserDestination
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }

