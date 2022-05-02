using System.ComponentModel.DataAnnotations;
using RegistrationApi.Models.CustomValidators;

namespace RegistrationApi.Models
{
    public class PolicyHolder
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
    }
}