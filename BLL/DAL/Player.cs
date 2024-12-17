using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Player
    {
        public int Id { get; set; }
        public bool IsFemale { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime? Birthdate { get; set; }

        [Required]
        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();

    }
}
