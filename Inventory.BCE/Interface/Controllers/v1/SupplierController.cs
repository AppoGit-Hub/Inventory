using AutoMapper;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Inventory.Domain.BCE;
using Inventory.Interface.Extensions;
using Inventory.Interface.DTO.Supplier;
using Inventory.Shared;
using Inventory.IBusiness.BCE;

namespace Inventory.Interface.Controllers.BCE.v1;

[ApiController]
[ApiVersion(1)]
[Route("/api/v{v:apiVersion}/[controller]")]
public class SuppliersController(ISupplierBL logic, IMapper mapper, ILogger<SuppliersController> logger): ControllerBase
{
    [
        HttpGet,
        ProducesResponseType<DataSourceResult<SupplierMinimalDTO>>(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        Authorize(Permissions.Supplier.READ)
    ]
    public async Task<ActionResult<DataSourceResult<SupplierMinimalDTO>>> SearchSuppliers(DataSourceRequestQuery request)
    {
        var result = await logic.Search(request.ToKendo());
        
        result.Data = result.Data.Cast<Supplier>().Select(mapper.Map<SupplierMinimalDTO>);
        return Ok(result.ToDataSourceResult<SupplierMinimalDTO>());
    }
  
    [
        HttpGet("{id:length(24)}"),
        ProducesResponseType<SupplierDTO>(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        Authorize(Permissions.Supplier.READ)
    ]
    public async Task<ActionResult<SupplierDTO>> Get(string id)
    {
        Supplier? entity = await logic.GetById(id);

        if (entity is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<SupplierDTO>(entity));
    }

    /*
    [
        HttpPost,
        ProducesResponseType(StatusCodes.Status201Created),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        Authorize(Permissions.Supplier.WRITE)
    ]
    public async Task<IActionResult> Create(SupplierCreationDTO create)
    {
        Supplier createdEntity = await logic.Create(mapper.Map<Supplier>(create));

        return CreatedAtAction(
            nameof(Get),
            new { id = createdEntity.Id },
            mapper.Map<SupplierDTO>(createdEntity)
        );
    }
    */

    /*
    [
        HttpPut,
        ProducesResponseType(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status409Conflict),
        Authorize(Permissions.Supplier.WRITE)
    ]
    public async Task<IActionResult> Update(SupplierUpdateDTO update)
    {
        await logic.Update(mapper.Map<Supplier>(update));

        return Ok();
    }
    */

    /*
    [
        HttpDelete("{id:length(24)}"),
        ProducesResponseType(StatusCodes.Status204NoContent),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
        ProducesResponseType(StatusCodes.Status404NotFound),
        Authorize(Permissions.Supplier.WRITE)
    ]
    public async Task<IActionResult> Delete(string id)
    {
        Supplier? entity = await logic.GetById(id);

        if (entity is null)
        {
            return NotFound();
        }

        await logic.Delete(entity);

        return NoContent();
    }
    */
}
