using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ids4Center.Mvc
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",
                    ClientSecrets =
                    {
                        new Secret("secret1".Sha256())
                    },

                    // 允许授予类型
                    // GrantType.ClientCredentials（客户端模式），没有用户参与交互，直接通过客户端Id和secret进行授权
                    AllowedGrantTypes = { GrantType.ClientCredentials, GrantType.ResourceOwnerPassword },
                    // 该客户端可以访问的资源集合
                    AllowedScopes = { "one-api" }
                },
                new Client
                {
                    ClientId = "client_b",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //AccessToken过期时间(秒),默认为3600秒/1小时
                    AccessTokenLifetime=3600,

                    //RefreshToken的最长生命周期
                    //AbsoluteRefreshTokenLifetime = 2592000,

                    //RefreshToken生命周期以秒为单位。默认为1296000秒
                    SlidingRefreshTokenLifetime = 2592000,//以秒为单位滑动刷新令牌的生命周期。

                    //刷新令牌时，将刷新RefreshToken的生命周期。RefreshToken的总生命周期不会超过AbsoluteRefreshTokenLifetime。
                    RefreshTokenExpiration = TokenExpiration.Sliding,

                    //AllowOfflineAccess 允许使用刷新令牌的方式来获取新的令牌
                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "one-api" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("one-api","OneAPI接口"),
            };
        }
    }
}
