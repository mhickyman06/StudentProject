using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentProject.Models.SeedRoles
{
    public class SetupIdentityDataSeeder : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public SetupIdentityDataSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedRoles>();
                await seeder.SeedRole();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}
