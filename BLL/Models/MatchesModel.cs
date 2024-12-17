using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class MatchesModel
    {
        public Matches Record { get; set; }

        public string Name => Record.Name;

        public string Date => !Record.Date.HasValue ? string.Empty : Record.Date.Value.ToString("MM/dd/yyyy");

        [DisplayName("Is Completed")]

        public string IsCompleted => Record.IsCompleted ? "Yes" : "No";

        
    }
}
