using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RegistrationApi.Data;
using RegistrationApi.Dtos;
using Xunit;

namespace RegistrationApiTests
{
    public class RegistrationControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public RegistrationControllerTests(CustomWebApplicationFactory application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task SendValidRequestWithDate()
        {
            var registration = new PolicyHolderRegistration
            {
                FirstName = "Blaze",
                Surname = "Fielding",
                ReferenceNumber = "AB-123456",
                DateOfBirth = new DateTime(1989,06,07)
            };

            var response = await PostRegistration(registration);

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task SendValidRequestWithEmail()
        {
            var registration = new PolicyHolderRegistration
            {
                FirstName = "Blaze",
                Surname = "Fielding",
                ReferenceNumber = "AB-123456",
                EmailAddress = "blazefielding@woodoak.com"
            };

            var response = await PostRegistration(registration);

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task SendInvalidRequestWithDateAndEmail()
        {
            var registration = new PolicyHolderRegistration
            {
                FirstName = "Blaze",
                Surname = "Fielding",
                ReferenceNumber = "AB-123456",
                DateOfBirth = new DateTime(1989,06,07),
                EmailAddress = "blazefielding@woodoak.com"
            };

            var response = await PostRegistration(registration);

            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SendInvalidRequestWithMalformedReferenceNumber()
        {
            var registration = new PolicyHolderRegistration
            {
                FirstName = "Blaze",
                Surname = "Fielding",
                ReferenceNumber = "AB-123456789",
                DateOfBirth = new DateTime(1989,06,07)
            };

            var response = await PostRegistration(registration);

            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task SendInvalidRequestWithMalformedEmailAddress()
        {
            var registration = new PolicyHolderRegistration
            {
                FirstName = "Blaze",
                Surname = "Fielding",
                ReferenceNumber = "AB-123456789",
                EmailAddress = "bf@woodoak.ac.uk"
            };

            var response = await PostRegistration(registration);

            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        private Task<HttpResponseMessage> PostRegistration(PolicyHolderRegistration policyHolderRegistration)
        {
            string requestJson = JsonConvert.SerializeObject(policyHolderRegistration);
            var content = new StringContent(requestJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return _client.PostAsync("/registration", content);
        }
    }
}