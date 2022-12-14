using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace ServerAPIs
{
    public static class Config
    {
        
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "powerbuilder",
                    ClientName = "PowerBuilder Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris =
                        new List<string> {
                       "http://172.16.0.154:8000/peat",
                       "my-powerbuilder-app://peat"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    AllowOfflineAccess = true,
                    RequirePkce=true,
                    RequireClientSecret=false
                },
                new Client
                {
                    ClientId = "react",
                    ClientName = "React Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris =
                        new List<string> {
                       "http://172.16.0.154:4000",
                       "http://172.16.0.154:4000/user",
                       "http://localhost:4000",
                       "http://localhost:4000/user"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    AllowOfflineAccess = true,
                    RequirePkce=true,
                    RequireClientSecret=false
                }
            };
        }
        
        public static List<TestUser> GetUsers()
        {

            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = 69118,
                country = "Germany"
            };

            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                }
            };
        }
        
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
        
    }
    
}
