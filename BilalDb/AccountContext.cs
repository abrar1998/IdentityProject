using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullIdentity_Project8._0.BilalDb
{
    public class AccountContext:IdentityDbContext
    {
        public AccountContext(DbContextOptions<AccountContext> opt):base(opt)
        {
            
        }
    }
}
