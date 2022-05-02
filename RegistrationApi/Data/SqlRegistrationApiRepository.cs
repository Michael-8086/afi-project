using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    public class SqlRegistrationApiRepository : IRegistrationApiRepository
    {
        private readonly RegistrationApiContext _context;

        public SqlRegistrationApiRepository(RegistrationApiContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        void IRegistrationApiRepository.RegisterPolicyHolder(PolicyHolder policyHolder)
        {
            if (policyHolder == null)
            {
                throw new ArgumentNullException(nameof(policyHolder));
            }

            _context.PolicyHolders.Add(policyHolder);
        }
    }
}