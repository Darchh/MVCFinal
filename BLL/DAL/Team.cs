using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Points { get; set; }

        public bool IsFull { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

    }
}