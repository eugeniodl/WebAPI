using System.ComponentModel.DataAnnotations;

namespace SharedModels
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
