using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using SozcuApp.Application.Features.News.Queries.GetList;
using SozcuApp.Application.Features.News.Queries.GetListSearch;

namespace SozcuApp.Application.Features.News.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.News, GetListNewsListItemDto>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.News>, GetListResponse<GetListNewsListItemDto>>().ReverseMap();

        CreateMap<Domain.Entities.News, GetListSearchNewsListItemDto>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.News>, GetListResponse<GetListSearchNewsListItemDto>>().ReverseMap();
    }
}
