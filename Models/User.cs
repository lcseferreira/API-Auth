namespace APIAuth.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
    }
}