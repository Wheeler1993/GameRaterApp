using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Game : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Releaser Releaser { get; set; }
        public int ReleaserId { get; set; }
        public string Cover { get; set; }
        public float AvgRating { get; set; }
        public string Details { get; set; }
        public List<GameRate> Rates { get; set; }
    }

    internal class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).UseIdentityColumn();
            builder.Property(game => game.Title).IsRequired(true);
            builder.HasOne<Releaser>(game => game.Releaser).WithMany(releaser => releaser.Games).HasForeignKey(game => game.ReleaserId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany<GameRate>(game => game.Rates).WithOne(rate => rate.Game).HasForeignKey(rate => rate.GameId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
