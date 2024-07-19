namespace SimpleWebAPI.Contracts.Customer
{
    public record CreateCustomerRequest(
        string FirstName,
        string Surname,
        string Email,
        string MobileNumber);
}
