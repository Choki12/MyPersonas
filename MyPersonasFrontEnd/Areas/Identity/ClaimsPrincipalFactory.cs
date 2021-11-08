using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyPersonasFrontEnd.Data;
using MyPersonasFrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyPersonasFrontEnd.Areas.Identity
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<User> //UserClaim factory, Security data stored about a user
    {
        private readonly IApiClient _apiClient;

        public ClaimsPrincipalFactory(IApiClient apiClient, UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
            _apiClient = apiClient;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            if (user.IsAdmin)
            {
                identity.MakeAdmin();
            }

            return identity;

        }
    }
}
