using System;

namespace UserServiceImposter.Models
{
    public class User
    {
        public string Username { get; set; }

        public int UserId { get; set; }

        public string PasswordHash { get; set; }

        public string EmailAddress { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public int EmployeeNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime EmailVerifiedDate { get; set; }

        public int LoginAttempts { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocked { get; set; }

        public int ExternalId { get; set; }

        public string Title { get; set; }

        public string Middlename { get; set; }

        public string PhoneNumber { get; set; }

        public string Mobile { get; set; }

        public string FaxNumber { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime PasswordTokenExpiryDate { get; set; }
    }
}