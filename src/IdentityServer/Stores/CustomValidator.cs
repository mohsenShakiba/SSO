using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Validation;

namespace IdentityServer.Stores
{
    public class CustomValidator: IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            await Task.Yield();
            context.Result = new GrantValidationResult(context.UserName, authenticationMethod: OidcConstants.AuthenticationMethods.Password);
        }
    }
}