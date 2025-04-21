using Microsoft.EntityFrameworkCore;
using Zura.Domain.Model.Todos.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zura.Infrastructure.Persistence.Configuration;

internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");

        builder.Property(t => t.Title)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(300);

        builder.OwnsOne(t => t.Status, status =>
        {
            status.Property(x=>x.Status)
                .HasColumnName("Status")
                .IsRequired();
        });
    }
}

