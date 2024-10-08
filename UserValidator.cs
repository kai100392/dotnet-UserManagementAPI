using FluentValidation;
using System;

namespace UserManagementAPI
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MaximumLength(128);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.DateOfBirth).Must(Be18YearsOrOlder).WithMessage("User must be 18 years or older");
            RuleFor(u => u.PhoneNumber).Matches(@"^\d{10}$").WithMessage("Phone number must have 10 digits");
        }

        private bool Be18YearsOrOlder(DateTime dateOfBirth)
        {
            return DateTime.Today.Year - dateOfBirth.Year >= 18;
        }
    }
}
