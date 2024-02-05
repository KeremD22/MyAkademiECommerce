using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademiECommerce.Order.Application.Features.CQRS.Handlers;
using MyAkademiECommerce.Order.Application.Features.Mediator.Commands;
using MyAkademiECommerce.Order.Application.Features.Mediator.Queries;

namespace MyAkademiECommerce.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderingController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            var values=await mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
           await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş Silindi.");
        }
    }
}
