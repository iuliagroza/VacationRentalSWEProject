namespace VacationRentalSWEProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        //hidden from the API
        public virtual ICollection<UserDestination> UserDestinations { get; set; } = new List<UserDestination>();
    }

}
