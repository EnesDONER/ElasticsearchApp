using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using SozcuApp.Application.Services.Repositories;

namespace SozcuApp.Application.Features.News.Queries.GetListSearch;

public class GetListSearchNewsQuery : IRequest<GetListResponse<GetListSearchNewsListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public required string Value { get; set; }

    public class GetListSearchNewsQueryHandler : IRequestHandler<GetListSearchNewsQuery, GetListResponse<GetListSearchNewsListItemDto>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetListSearchNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListSearchNewsListItemDto>> Handle(GetListSearchNewsQuery request, CancellationToken cancellationToken)
        {
                    var news = await _newsRepository.GetListSearchAsync(
                     indexName: "news",
                     fieldName: "text",
                     value: request.Value.ToLower(),
                     index: request.PageRequest.PageIndex,
                     size: request.PageRequest.PageSize,
                     cancellationToken:cancellationToken
                 );

            return _mapper.Map<GetListResponse<GetListSearchNewsListItemDto>>(news);
        }
    }
}