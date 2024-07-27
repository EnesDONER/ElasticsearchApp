using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using SozcuApp.Application.Services.Repositories;

namespace SozcuApp.Application.Features.News.Queries.GetList;

public class GetListNewsQuery : IRequest<GetListResponse<GetListNewsListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListNewsQueryHandler : IRequestHandler<GetListNewsQuery, GetListResponse<GetListNewsListItemDto>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetListNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNewsListItemDto>> Handle(GetListNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.GetListAsync(
                    indexName: "news",
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken:cancellationToken
                );
            return _mapper.Map<GetListResponse<GetListNewsListItemDto>>(news);
        }
    }
}
