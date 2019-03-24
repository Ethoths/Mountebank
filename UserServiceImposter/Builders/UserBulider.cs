using System;
using UserServiceImposter.Models;

namespace UserServiceImposter.Builders
{
    public class UserBuilder
    {
        private readonly string _username;
        private int _userId = Randomiser.Int();
        private string _passwordHash = Randomiser.String;
        private string _emailAddress = Randomiser.EmailAddress;
        private string _forename = Randomiser.ShortString(10);
        private string _surname = Randomiser.ShortString(10);
        private int _employeeNumber = Randomiser.Int();
        private DateTime _createdDate = Randomiser.PastDate;
        private DateTime _modifiedDate = Randomiser.PastDate;
        private DateTime _lastLoginDate = Randomiser.PastDate;
        private DateTime _emailVerifiedDate = Randomiser.PastDate;
        private int _loginAttempts;
        private bool _isActive = true;
        private bool _isLocked;
        private int _externalId = Randomiser.Int();
        private string _title = Randomiser.String;
        private string _middlename = Randomiser.ShortString(10);
        private string _phoneNumber = Randomiser.LandlineNumber;
        private string _mobile = Randomiser.MobileNumber;
        private string _faxNumber = Randomiser.LandlineNumber;
        private string _passwordResetToken = Randomiser.String;
        private DateTime _startDate = Randomiser.PastDate;
        private DateTime _passwordTokenExpiryDate = Randomiser.FutureDate;

        public UserBuilder UserId(int userId)
        {
            _userId = userId;

            return this;
        }

        public UserBuilder PasswordHash(string passwordHash)
        {
            _passwordHash = passwordHash;

            return this;
        }

        public UserBuilder EmailAddress(string emailAddress)
        {
            _emailAddress = emailAddress;

            return this;
        }

        public UserBuilder Forename(string forename)
        {
            _forename = forename;

            return this;
        }

        public UserBuilder Surname(string surname)
        {
            _surname = surname;

            return this;
        }

        public UserBuilder EmployeeNumber(int employeeNumber)
        {
            _employeeNumber = employeeNumber;

            return this;
        }

        public UserBuilder CreatedDate(DateTime createdDate)
        {
            _createdDate = createdDate;

            return this;
        }

        public UserBuilder ModifiedDate(DateTime modifiedDate)
        {
            _modifiedDate = modifiedDate;

            return this;
        }

        public UserBuilder LastLoginDate(DateTime lastLoginDate)
        {
            _lastLoginDate = lastLoginDate;

            return this;
        }

        public UserBuilder EmailVerifiedDate(DateTime emailVerifiedDate)
        {
            _emailVerifiedDate = emailVerifiedDate;

            return this;
        }

        public UserBuilder LoginAttempts(int loginAttempts)
        {
            _loginAttempts = loginAttempts;

            return this;
        }

        public UserBuilder IsActive(bool isActive)
        {
            _isActive = isActive;

            return this;
        }

        public UserBuilder IsLocked(bool isLocked)
        {
            _isLocked = isLocked;

            return this;
        }

        public UserBuilder ExternalId(int externalId)
        {
            _externalId = externalId;

            return this;
        }

        public UserBuilder Title(string title)
        {
            _title = title;

            return this;
        }

        public UserBuilder Middlename(string middlename)
        {
            _middlename = middlename;

            return this;
        }

        public UserBuilder PhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;

            return this;
        }

        public UserBuilder Mobile(string mobile)
        {
            _mobile = mobile;

            return this;
        }

        public UserBuilder FaxNumber(string faxNumber)
        {
            _faxNumber = faxNumber;

            return this;
        }

        public UserBuilder PasswordResetToken(string passwordResetToken)
        {
            _passwordResetToken = passwordResetToken;

            return this;
        }

        public UserBuilder StartDate(DateTime startDate)
        {
            _startDate = startDate;

            return this;
        }

        public UserBuilder PasswordTokenExpiryDate(DateTime passwordTokenExpiryDate)
        {
            _passwordTokenExpiryDate = passwordTokenExpiryDate;

            return this;
        }

        public UserBuilder() : this(Randomiser.String) { }

        public UserBuilder(string username)
        {
            _username = username;

            switch (username)
            {
                case "Admin":
                    _passwordHash = "p8T9E9dTMZH1uTU6bxiyTkN8EAQyscDtiSRUQWnnhaoN6baSO0pQJ921zatMqBBb1THHQEBFNQKNYjUmJqaddg==:gsX0m9b1OezfalHtwws9cNMJBgyChr6W+EAxCE/X+NmWABsRH9GV8dD3z8uR1+F9H00P73XdteUvuPivS/kyjw=="; // Password1
                    break;
            }
        }

        public User Build()
        {
            return new User
            {
                Username = _username,
                UserId = _userId,
                PasswordHash = _passwordHash,
                EmailAddress = _emailAddress,
                Forename = _forename,
                Surname = _surname,
                EmployeeNumber = _employeeNumber,
                CreatedDate = _createdDate,
                ModifiedDate = _modifiedDate,
                LastLoginDate = _lastLoginDate,
                EmailVerifiedDate = _emailVerifiedDate,
                LoginAttempts = _loginAttempts,
                IsActive = _isActive,
                IsLocked = _isLocked,
                ExternalId = _externalId,
                Title = _title,
                Middlename = _middlename,
                PhoneNumber = _phoneNumber,
                Mobile = _mobile,
                FaxNumber = _faxNumber,
                PasswordResetToken = _passwordResetToken,
                StartDate = _startDate,
                PasswordTokenExpiryDate = _passwordTokenExpiryDate
            };
        }
    }
}
