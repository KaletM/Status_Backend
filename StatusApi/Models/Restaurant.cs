namespace StatusApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string CreatedAt { get; set; }
    }
}