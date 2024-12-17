using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class TeamModel
    {
        public Team Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Slot Status")]

        public string IsFull => Record.IsFull ? "All Slots are Full" : "Slots Available";

        public string Points => Record.Points.HasValue ? Record.Points.Value.ToString("N2") : "";

    }
}
