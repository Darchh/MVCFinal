namespace BLL.DAL
{
    public class Payment
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int MatchesId { get; set; }

        public Matches Matches { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? Amount { get; set; }
    }
}
