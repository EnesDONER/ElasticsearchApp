using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using SozcuApp.Application.Features.News.Queries.GetList;
using SozcuApp.Application.Features.News.Queries.GetListSearch;

namespace SozcuApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListNewsQuery { PageRequest = pageRequest });

            return Ok(response);
        }

        [HttpGet("{value}")]
        public async Task<IActionResult> GetListSearch([FromRoute] string value, [FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListSearchNewsQuery { Value= value, PageRequest = pageRequest });

            return Ok(response);
        }
    }
}
