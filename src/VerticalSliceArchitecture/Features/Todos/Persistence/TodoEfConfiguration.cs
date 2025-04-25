using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.Features.Todos.Domain;

namespace VerticalSliceArchitecture.Features.Todos.Persistence;

public class TodoEfConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Text)
            .IsRequired();
    }
}
