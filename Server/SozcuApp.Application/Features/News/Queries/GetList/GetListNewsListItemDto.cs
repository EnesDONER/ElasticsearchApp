namespace SozcuApp.Application.Features.News.Queries.GetList;

public class GetListNewsListItemDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}
