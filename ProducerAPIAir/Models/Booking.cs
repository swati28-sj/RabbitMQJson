namespace ProducerAPIAir.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string PassengerName { get; set; } = "";
        public string PassportNo { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public int Status { get; set; }
    }
}
