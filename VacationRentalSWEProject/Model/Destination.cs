namespace VacationRentalSWEProject.Model
{
    public class Destination
    {
        public int Id { get; set; }
        public string Geolocation { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<UserDestination> UserDestinations { get; set; } = new List<UserDestination>();
    }

}
