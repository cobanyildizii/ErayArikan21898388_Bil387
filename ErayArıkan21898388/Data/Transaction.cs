namespace ErayArıkan21898388.Data
{
    public class Transaction
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
