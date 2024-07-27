using Core.Persistence.Repositories;

namespace SozcuApp.Domain.Entities;

public class News :Entity<Guid>
{
    public string ImageUrl { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
