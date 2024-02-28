namespace CustomersApp.Common.Models;

public class CustomerDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? NIP { get; set; }
    public AddressDto Address { get; set; } = new AddressDto();

}
