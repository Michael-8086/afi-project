using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Data;
using RegistrationApi.Dtos;
using RegistrationApi.Models;

namespace RegistrationApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationApiRepository _repository;
        private readonly IMapper _mapper;

        public RegistrationController(IRegistrationApiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //POST /registration
        [HttpPost]
        public ActionResult<PolicyHolderRegistrationResult> RegisterPolicyHolder(PolicyHolderRegistration policyHolderRegistration)
        {
            // TODO: Could implement this as custom validator for data annotation with more time
            if (!(policyHolderRegistration.DateOfBirth != null ^ policyHolderRegistration.EmailAddress != null))
            {
                // We require exactly one of DOB or email
                return BadRequest();
            }

            var registrationModel = _mapper.Map<PolicyHolder>(policyHolderRegistration);
            _repository.RegisterPolicyHolder(registrationModel);
            _repository.SaveChanges();

            var registrationResult = _mapper.Map<PolicyHolderRegistrationResult>(registrationModel);

            return CreatedAtAction("RegisterPolicyHolder", new {Id = registrationResult.Id}, registrationResult);
        }
    }
}