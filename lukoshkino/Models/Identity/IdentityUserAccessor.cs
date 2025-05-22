using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;


namespace lukoshkino.Models
{
    public sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager, AuthenticationStateProvider authenticationStateProvider)
    {
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }

		public async Task<ApplicationUser> GetCurrentUserAsync()
		{
			var userClaims = (await authenticationStateProvider.GetAuthenticationStateAsync()).User;
			var user = await userManager.GetUserAsync(userClaims);

			return user;
		}
	}
}
