using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozcuApp.Application.Features.News.Queries.GetListSearch;

public class GetListSearchNewsListItemDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}
