using HromadaWEB.BL.Interfaces;
using HromadaWEB.BL.Services;
using HromadaWEB.Models.Models;
using HromadaWEB.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IProductService productService;

        public ProductController(IMediator mediator, IProductService productService)
        {
            this.mediator = mediator;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetProducts() 
        {
            var product = await mediator.Send(new GetProductsQuery());
            return Ok(new BaseResponseModel { IsSuccess = true, Data = product});
        }
    }
}
