namespace SimpleWebAPI.Contracts.Customer
{
    public record CustomerRequest(
        string FirstName,
        string Surname,
        string Email,
        string MobileNumber);
}
