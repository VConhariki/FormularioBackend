using FormularioBackend.Enum;
using System.ComponentModel.DataAnnotations;

namespace FormularioBackend.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
    }
}
