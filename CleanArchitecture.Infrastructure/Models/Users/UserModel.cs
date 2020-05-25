namespace CleanArchitecture.Infrastructure.Models.Users
{
    using System;

    public class UserModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
