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
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IRepository<AccountType> _accountTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
    
        public AccountTypeService(IUnitOfWork unitOfWork, IRepository<AccountType> accountTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _accountTypeRepository = accountTypeRepository;
          
        }

        public Task<IEnumerable<AccountType>> GetAllAccountTypesAsync()
        {
            return _accountTypeRepository.GetAllAsync();
        }

        public async Task CreateAccountTypeAsync(AccountType accountType)
        {
            await _accountTypeRepository.AddAsync(accountType);
        }

        public async Task UpdateAccountTypeAsync(Guid id, AccountType updatedAccountType)
        {
          
            var existingAccountType = await _accountTypeRepository.GetByIdAsync(id);
            if (existingAccountType == null)
            {
               
                throw new ArgumentException("Account type not found.");
            }
            existingAccountType.Name = updatedAccountType.Name;

            await _accountTypeRepository.UpdateAsync(existingAccountType);
        }

        public async Task DeleteAccountTypeAsync(Guid id)
        {
            var accountType = await _accountTypeRepository.GetByIdAsync(id);
            if (accountType == null)
            {
                throw new ArgumentException("Account type not found.");
            }

            await _accountTypeRepository.DeleteAsync(accountType);
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveAsync();
        }
    }
}
