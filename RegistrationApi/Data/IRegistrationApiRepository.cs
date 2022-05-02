using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    public interface IRegistrationApiRepository
    {
        bool SaveChanges();
        void RegisterPolicyHolder(PolicyHolder policyHolder);
    }
}