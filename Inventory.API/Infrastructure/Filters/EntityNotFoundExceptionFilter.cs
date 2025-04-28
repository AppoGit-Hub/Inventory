using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Inventory.IDAL.Exceptions;

namespace Inventory.API.Infrastructure.Filters;

public class EntityNotFoundExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is not EntityNotFoundException)
			return;
		
		context.Result = new NotFoundResult();
	}
}