using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Matches
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        public bool IsCompleted { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
