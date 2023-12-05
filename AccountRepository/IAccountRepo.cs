using FullIdentity_Project8._0.Models;
using Microsoft.AspNetCore.Identity;

namespace FullIdentity_Project8._0.AccountRepository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUp(SignUpModel signup);
        Task<SignInResult> SignIn(SignInModel signin);
        Task SignOut();
    }
}
