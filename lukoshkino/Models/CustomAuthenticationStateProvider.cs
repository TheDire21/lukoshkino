using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

namespace lukoshkino.Models
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task MarkUserAsAuthenticated(ApplicationUser applicationUser)
        {
            ApplicationRole applicationRole;
            using (var db = new ApplicationContext()) 
            { 
                applicationRole = db.Roles.First(x => x.Id == applicationUser.ApplicationRoleId);
            }
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, applicationUser.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, applicationRole.Name),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
