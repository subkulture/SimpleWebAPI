﻿namespace SimpleWebAPI.Domain.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }

        private bool IsEmailValid()
        {
            throw new NotImplementedException();
        }

        private bool IsMobileNumberValid()
        {
            throw new NotImplementedException();
        }
    }
}
