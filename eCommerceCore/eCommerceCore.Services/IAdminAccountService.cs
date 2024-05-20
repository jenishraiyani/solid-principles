using eCommerceCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Services
{
    public interface IAdminAccountService
    {
        Task<IEnumerable<AdminAccount>> GetAllAdminAccountsAsync();
        Task CreateAdminAccountAsync(AdminAccount adminAccount);
        Task UpdateAdminAccountAsync(Guid id, AdminAccount updatedAdminAccount);
        Task DeleteAdminAccountAsync(Guid id);
        Task SaveChangesAsync();
    }
}
