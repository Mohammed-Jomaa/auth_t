using System.ComponentModel.DataAnnotations;

namespace auth_task.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAT { get; set; }

    }
}
