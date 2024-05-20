using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Domain.Models
{
    public class AdminAccount
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid AccountTypeId { get; set; }
        public string Password { get; set; }
        public virtual AccountType? AccountType { get; set; }
    }
}
