using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPersonasFrontEnd.Data;

[assembly: HostingStartup(typeof(MyPersonasFrontEnd.Areas.Identity.IdentityHostingStartup))]
namespace MyPersonasFrontEnd.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlite("Data Source=mysecurity.db"));

            


                services.AddDefaultIdentity<User>()
                        .AddEntityFrameworkStores<IdentityDbContext>()
                        .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>();
            });


        }
    }
}