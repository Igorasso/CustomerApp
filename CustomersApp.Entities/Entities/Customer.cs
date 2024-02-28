namespace CustomersApp.Database.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? NIP { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; } = default!;

    }
}
