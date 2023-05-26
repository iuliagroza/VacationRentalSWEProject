namespace DublaDoi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsAdmin { get; set; }
        public string Password { get; set; }

        //hidden from the API
        public virtual ICollection<UserDestination> UserDestinations { get; set; } = null!;
    }
}
