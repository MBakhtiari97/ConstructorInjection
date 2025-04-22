using Microsoft.AspNetCore.Mvc;
using Service.UserServices;

namespace ConstructorInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class AppUserController : ControllerBase
{
    private readonly IUserServices _userServices;
    public AppUserController(IUserServices userServices)
    {
        _userServices = userServices;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _userServices.GetUserAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
