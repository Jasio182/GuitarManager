namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public bool IsAdmin { get; set; }
    }
}
