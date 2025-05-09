using AutoMapper;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Inventory.Domain.Entities;
using Inventory.IBusiness;
using Inventory.Interface.Extensions;
using Inventory.Interface.DTO.Order;
using Inventory.Shared;

namespace Inventory.Interface.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("/api/v{v:apiVersion}/[controller]")]
public class OrdersController(IOrderBL logic, IMapper mapper, ILogger<OrdersController> logger): ControllerBase
{
    [
        HttpGet,
        ProducesResponseType<DataSourceResult<OrderMinimalDTO>>(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        //Authorize(Permissions.Order.READ)
    ]
    public async Task<ActionResult<DataSourceResult<OrderMinimalDTO>>> SearchOrders(DataSourceRequestQuery request)
    {
        var result = await logic.Search(request.ToKendo());
        
        result.Data = result.Data.Cast<Order>().Select(mapper.Map<OrderMinimalDTO>);
        return Ok(result.ToDataSourceResult<OrderMinimalDTO>());
    }
  
    [
        HttpGet("{id:length(24)}"),
        ProducesResponseType<OrderDTO>(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        //Authorize(Permissions.Order.READ)
    ]
    public async Task<ActionResult<OrderDTO>> Get(string id)
    {
        Order? entity = await logic.GetById(id);

        if (entity is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<OrderDTO>(entity));
    }
  
    [
        HttpPost,
        ProducesResponseType(StatusCodes.Status201Created),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        //Authorize(Permissions.Order.WRITE)
    ]
    public async Task<IActionResult> Create(OrderCreationDTO create)
    {
        Order createdEntity = await logic.Create(mapper.Map<Order>(create));

        return CreatedAtAction(
            nameof(Get),
            new { id = createdEntity.Id },
            mapper.Map<OrderDTO>(createdEntity)
        );
    }

    [
        HttpPut,
        ProducesResponseType(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status409Conflict),
        //Authorize(Permissions.Order.WRITE)
    ]
    public async Task<IActionResult> Update(OrderUpdateDTO update)
    {
        await logic.Update(mapper.Map<Order>(update));

        return Ok();
    }

    [
        HttpDelete("{id:length(24)}"),
        ProducesResponseType(StatusCodes.Status204NoContent),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        //Authorize(Permissions.Order.WRITE)
    ]
    public async Task<IActionResult> Delete(string id)
    {
        Order? entity = await logic.GetById(id);

        if (entity is null)
        {
            return NotFound();
        }

        await logic.Delete(entity);

        return NoContent();
    }
}
