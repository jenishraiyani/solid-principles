using eCommerceCore.Domain.Models;
using eCommerceCore.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
              : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AdminAccount> AdminAccount { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminAccountConfiguration(_configuration));
          
        }
    }
}
