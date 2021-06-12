using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace IdentityServer.Stores
{
    public class DefaultResourceStore: IResourceStore
    {
        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var resource = await GetAllResourcesAsync();
            return resource.IdentityResources;
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var resource = await GetAllResourcesAsync();
            return resource.ApiScopes;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var resource = await GetAllResourcesAsync();
            return resource.ApiResources;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var resource = await GetAllResourcesAsync();
            return resource.ApiResources;
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            await Task.Yield();

            return new Resources
            {
                ApiResources = new List<ApiResource>
                {
                },
                ApiScopes = new List<ApiScope>
                {
                },
                IdentityResources = new List<IdentityResource>
                {
                    new IdentityResource("openidt", new string[] {"TEST"}),
                    new IdentityResource("openid", new string[] {"TEST"}),
                },
                
            };
        }
    }
}