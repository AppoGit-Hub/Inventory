using System.Reflection;
using Asp.Versioning;
using Inventory.IBusiness;
using Inventory.Interface.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Interface.Controllers.v1;

[
	ApiVersion(1),
	ApiController,
	Route("api/v{version:apiVersion}/[controller]")
]
public class DiagnosticsController(ILogger<DiagnosticsController> logger, IDiagnosticsBL logic)
	: Controller
{
	[
		HttpGet,
		ProducesResponseType(typeof(DiagnosticsDTO), StatusCodes.Status200OK),
	]
	public async Task<ActionResult<DiagnosticsDTO>> Get()
	{
		var version = Assembly.GetExecutingAssembly().GetName().Version;
		var user = HttpContext.User.Identity;
		var databaseOnline = await logic.IsDatabaseOnlineAsync();

		return Ok(
			new DiagnosticsDTO
			{
				AssemblyVersion = version?.ToString(4) ?? throw new ArgumentNullException(nameof(version)),
				IsAuthenticated = user is not null && user.IsAuthenticated,
				DatabaseOnline = databaseOnline
			}
		);
	}
}