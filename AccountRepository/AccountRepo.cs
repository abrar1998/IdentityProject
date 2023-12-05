using FullIdentity_Project8._0.Models;
using Microsoft.AspNetCore.Identity;

namespace FullIdentity_Project8._0.AccountRepository
{
    public class AccountRepo:IAccountRepo
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<IdentityResult> SignUp(SignUpModel signup)
        {
            var user = new IdentityUser
            {
                UserName = signup.Email,
                Email = signup.Email,
            };

            var result = await userManager.CreateAsync(user, signup.Password);
            if(!string.IsNullOrEmpty(signup.Role.ToString()))
            {
                await userManager.AddToRoleAsync(user, signup.Role.ToString());
            }
            else
            {
                await userManager.AddToRoleAsync(user, RolesClass.Students);
            }
            
            return result;

        }

        public async Task<SignInResult> SignIn(SignInModel signin)
        {
            var result = await signInManager.PasswordSignInAsync(signin.Email, signin.Password, signin.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }


    }
}
