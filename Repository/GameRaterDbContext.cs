using Repository.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class GameRaterDbContext : ApiAuthorizationDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRate> GamesRates { get; set; }
        public DbSet<Releaser> Releasers { get; set; }
        public GameRaterDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
