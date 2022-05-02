using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    /// <summary>
    /// Mock repository for testing
    /// </summary>
    public class MockRegistrationApiRepository : IRegistrationApiRepository
    {
        public bool SaveChanges()
        {
            return true;
        }

        void IRegistrationApiRepository.RegisterPolicyHolder(PolicyHolder policyHolder)
        {
            policyHolder.Id = 1;
        }
    }
}