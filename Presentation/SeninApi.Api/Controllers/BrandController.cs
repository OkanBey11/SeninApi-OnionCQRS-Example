using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeninApi.Application.Features.Brands.Commands.CreateBrand;
using SeninApi.Application.Features.Brands.Queries.GetAllBrands;

namespace SeninApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await mediator.Send(new GetAllBrandQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
