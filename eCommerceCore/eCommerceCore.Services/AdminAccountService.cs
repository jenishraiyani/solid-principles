using eCommerceCore.Domain.Models;
using eCommerceCore.Infrastructure.Repository;
using eCommerceCore.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Services
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly IRepository<AdminAccount> _adminAccountRepository;
        private readonly IUnitOfWork _unitOfWork;
  

        public AdminAccountService(IUnitOfWork unitOfWork, IRepository<AdminAccount> adminAccountRepository)
        {
            _unitOfWork = unitOfWork;
            _adminAccountRepository = adminAccountRepository;
           
        }

        public Task<IEnumerable<AdminAccount>> GetAllAdminAccountsAsync()
        {
            return _adminAccountRepository.GetAllAsync();
        }

        public async Task CreateAdminAccountAsync(AdminAccount adminAccount)
        {
            await _adminAccountRepository.AddAsync(adminAccount);
        }

        public async Task UpdateAdminAccountAsync(Guid id, AdminAccount updatedAdminAccount)
        {
            var existingAdminAccount = await _adminAccountRepository.GetByIdAsync(id);
            if (existingAdminAccount == null)
            {
                throw new ArgumentException("Admin account not found.");
            }
            existingAdminAccount.FirstName = updatedAdminAccount.FirstName;
            existingAdminAccount.MiddleName = updatedAdminAccount.MiddleName;
            existingAdminAccount.LastName = updatedAdminAccount.LastName;
           
            await _adminAccountRepository.UpdateAsync(existingAdminAccount);
        }

        public async Task DeleteAdminAccountAsync(Guid id)
        {
            var adminAccount = await _adminAccountRepository.GetByIdAsync(id);
            if (adminAccount == null)
            {
                
                throw new ArgumentException("Admin account not found.");
            }

          
            await _adminAccountRepository.DeleteAsync(adminAccount);
        }

        public async Task SaveChangesAsync()
        { 
            await _unitOfWork.SaveAsync();
        }
    }
}
