using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class PlayerModel
    {
        public Player Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        [DisplayName("Female")]
        
        public string IsFemale => Record.IsFemale ? "Yes" : "No";

        [DisplayName("Birth Date")]
        public string Birthdate => !Record.Birthdate.HasValue ? string.Empty : Record.Birthdate.Value.ToString("MM/dd/yyyy");
        public string Team => Record.Team?.Name;
        public string Payments => string.Join("<br>", Record.Payments?.Select(pp => pp.Player?.Name + " payed for " + pp.Matches?.Name));
        [DisplayName("Payments")]
        public List<int> PaymentIds 
        {
            get => Record.Payments?.Select(pa => pa.MatchesId).ToList();
            set => Record.Payments = value.Select(v => new Payment() { MatchesId = v }).ToList(); 
        }
    }
}
