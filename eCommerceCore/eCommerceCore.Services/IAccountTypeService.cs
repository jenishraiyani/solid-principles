using eCommerceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Services
{
    public interface IAccountTypeService
    {
        Task<IEnumerable<AccountType>> GetAllAccountTypesAsync();
        Task CreateAccountTypeAsync(AccountType accountType);
        Task UpdateAccountTypeAsync(Guid id, AccountType updatedAccountType);
        Task DeleteAccountTypeAsync(Guid id);
        Task SaveChangesAsync();
    }
}
