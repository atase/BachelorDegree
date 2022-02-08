using Kidney.DataAccess.Entities;

namespace DataAccess.Entities
{
    public class CompatibilityScore
    {
        public int Id { get; set; }
        public int GiverId { get; set; }
        public Giver Giver { get; set; }
        public int ReceiverId { get; set; }
        public Receiver Receiver {get; set;}
        public int Score { get; set; }
    }
}
