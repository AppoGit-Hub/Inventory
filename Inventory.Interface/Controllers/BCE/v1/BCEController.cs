using Asp.Versioning;
using AutoMapper;
using Inventory.Domain.BCE;
using Inventory.IBusiness.BCE;
using Inventory.Interface.DTO.SupplierBCE;
using Inventory.Interface.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Interface.Controllers.BCE.v1;

[ApiController]
[ApiVersion(1)]
[Route("/api/v{v:apiVersion}/[controller]")]
public class BCEController(IBCEBL logic, IMapper mapper) : ControllerBase
{
    [
        HttpGet,
        ProducesResponseType<DataSourceResult<SupplierBCEMinimalDTO>>(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
    ]
    public async Task<ActionResult<DataSourceResult<SupplierBCEMinimalDTO>>> Select(DataSourceRequestQuery request)
    {
        var result = await logic.Search(request.ToKendo());

        result.Data = result.Data.Cast<SupplierBCE>().Select(mapper.Map<SupplierBCEMinimalDTO>);
        return Ok(result.ToDataSourceResult<SupplierBCEMinimalDTO>());
    }
    
    [
        HttpPost,
        ProducesResponseType(StatusCodes.Status400BadRequest),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status403Forbidden),
    ]
    public async Task<IActionResult> UnZip(IFormFile zip)
    {
        if (zip == null || zip.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        try
        {
            /*
            using (var stream = new MemoryStream())
            {
                await zip.CopyToAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
            }
            */

            logic.UnZip(zip.FileName);

            return Ok(new { zip.FileName });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
