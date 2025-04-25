using VerticalSliceArchitecture.Features.Todos.Domain;

namespace VerticalSliceArchitecture.Common.Persistence;

public partial class AppDbContext
{
    public DbSet<Todo> Todos { get; set; } = null!;
}