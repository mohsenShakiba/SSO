using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer.Stores
{
    public class CustomProfileService: IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await Task.Yield();
            var claims = new List<Claim>
            {
                new Claim("name_identifier", "10")
            };
            
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.Yield();
            context.IsActive = true;
        }
    }
}