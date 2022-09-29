using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class BaseController : Controller
{
    protected Guid UserId
    {
        get
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return userId != null ? Guid.Parse(userId) : Guid.Empty;
                
            }

            return default;
        }
    }
}