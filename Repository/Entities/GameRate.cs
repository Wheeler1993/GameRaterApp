using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class GameRate : Entity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public double Rate { get; set; }
    }

    internal class GameRateEntityTypeConfiguration : IEntityTypeConfiguration<GameRate>
    {
        public void Configure(EntityTypeBuilder<GameRate> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).UseIdentityColumn();
            builder.Property(game => game.Rate).IsRequired(true);
            builder.HasOne<User>(game => game.User).WithMany().HasForeignKey(rate => rate.UserId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
