using System;
using RegistrationApi.Models.CustomValidators;
using Xunit;

namespace RegistrationApiTests
{
    public class MinimumAgeAttributeTests
    {
        private readonly MinimumAge _validation;

        public MinimumAgeAttributeTests() => _validation = new MinimumAge(18);

        [Fact]
        public void DateMeetsMinimumAgeRequirement()
        => Assert.True(_validation.IsValid(new DateTime(1989,07,07)));

        [Fact]
        public void DateDoesNotMeetMinimumAgeRequirement()
        => Assert.False(_validation.IsValid(DateTime.Now));
    }
}
