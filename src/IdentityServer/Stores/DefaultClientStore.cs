using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace IdentityServer.Stores
{
    public class DefaultClientStore: IClientStore
    {
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            await Task.Yield();

            if (clientId != "test")
            {
                return default;
            }
            
            return new Client
            {
                Claims = new List<ClientClaim> {new ClientClaim("Test", "true")},
                ClientId = clientId,
                Enabled = true,
                ClientName = "test",
                AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string> { "openidt", "openid"},
                RedirectUris = new List<string> {"http://localhost:4200/auth-callback"},
                ProtocolType = IdentityServerConstants.ProtocolTypes.OpenIdConnect,
                AllowedGrantTypes = new List<string> {"implicit"},
                ClientSecrets = new List<Secret> {new Secret("123")},
                EnableLocalLogin = true,
                IncludeJwtId = true,
            };
        }
    }
}