namespace SimpleWebAPI.Contracts.Customer
{
    public record CustomerResponse(
        int Id,
        string? FirstName,
        string? Surname,
        string? Email,
        string? MobileNumber);
}
