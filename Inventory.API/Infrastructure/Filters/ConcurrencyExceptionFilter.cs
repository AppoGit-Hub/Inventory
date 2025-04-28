using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Inventory.IDAL.Exceptions;

namespace Inventory.API.Infrastructure.Filters;

public class ConcurrencyExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ConcurrentEditionDetectedException exception)
            return;
        
        context.Result = new ConflictResult();
    }
}
