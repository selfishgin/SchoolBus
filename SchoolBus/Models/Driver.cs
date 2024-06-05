namespace SchoolBusManagement.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string License { get; set; }
        public string Address { get; set; }
        public int BusId { get; set; }
    }
}
