using System.Collections.Generic;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Identity.Core;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResources.Address(),
            new IdentityResource (Constants.StandardScopes.Roles, new List<string> { "role" })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> { new ApiScope(Constants.StandardScopes.EShopApi )};

    
    public static IList<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource(Constants.StandardScopes.EShopApi)
            {
                Scopes = {Constants.StandardScopes.EShopApi}
            }
        };


    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = new [] { new Secret("secret".Sha512()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    Constants.StandardScopes.EShopApi
                }
            }
        };
}