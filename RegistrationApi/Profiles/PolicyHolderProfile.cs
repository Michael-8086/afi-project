using AutoMapper;
using RegistrationApi.Dtos;
using RegistrationApi.Models;

namespace RegistrationApi.Profiles
{
    public class PolicyHolderProfile : Profile
    {
        public PolicyHolderProfile()
        {
            CreateMap<PolicyHolder, PolicyHolderRegistrationResult>();
            CreateMap<PolicyHolderRegistration, PolicyHolder>();
        }
    }
}