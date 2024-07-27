namespace SozcuApp.Blazor.Models;

public class NewsView
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}
