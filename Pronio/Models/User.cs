namespace Pronia.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
    }
}
