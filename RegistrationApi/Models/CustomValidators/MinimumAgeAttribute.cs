using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.Models.CustomValidators
{
    public class MinimumAge : ValidationAttribute
    {
        public MinimumAge(int age) => Age = age;

        public int Age { get; }

        public string GetErrorMessage() => $"You must be at least {Age} years old.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            
            var dateOfBirth = (DateTime)value!;

            if (dateOfBirth.AddYears(Age) <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
    }
}