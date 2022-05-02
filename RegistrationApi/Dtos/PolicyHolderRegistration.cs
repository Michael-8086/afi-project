using System.ComponentModel.DataAnnotations;
using RegistrationApi.Models.CustomValidators;

namespace RegistrationApi.Dtos
{
    public class PolicyHolderRegistration
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The first name must be between 3 and 50 characters")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The surname must be between 3 and 50 characters")]
        public string? Surname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{2}-\d{6}$", ErrorMessage = "The reference number must of the format XX-999999")]
        public string? ReferenceNumber { get; set; }
        [MinimumAge(18)]
        public DateTime? DateOfBirth { get; set; }
        [RegularExpression(@"^\w{4,}@\w{2,}(?:\.com|\.co\.uk)$")]
        public string? EmailAddress { get; set; }
    }
}