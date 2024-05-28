using System.ComponentModel.DataAnnotations;

namespace Ejemplo02.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
