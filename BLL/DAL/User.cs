using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is Required!")] 
        [StringLength(50, ErrorMessage = "User Name must be maximum {1} characters!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is Required!")]
        [StringLength(20, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
