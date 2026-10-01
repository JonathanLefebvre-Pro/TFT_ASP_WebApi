using AppCore.Features.Results;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Extensions;

public static class ControllerBaseExtensions
{
    public static IActionResult FromResult(this ControllerBase controller, Result result)
    {
        if (result.IsSuccess)
            return controller.NoContent();

        return controller.NotFound(result.Error);
    }

    public static IActionResult FromResult<TResult>(
        this ControllerBase controller,
        Result<TResult> result
    )
    {
        if (result.IsSuccess)
            return controller.Ok(result.Data);

        return controller.NotFound(result.Error);
    }
}
