using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Releaser : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }

    internal class ReleaserEntityTypeConfiguration : IEntityTypeConfiguration<Releaser>
    {
        public void Configure(EntityTypeBuilder<Releaser> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).UseIdentityColumn();
            builder.Property(releaser => releaser.Name).IsRequired(true);
        }
    }
}
