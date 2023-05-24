namespace VacationRentalSWEProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<UserDestination> UserDestinations { get; set; } = new List<UserDestination>();
    }

}
