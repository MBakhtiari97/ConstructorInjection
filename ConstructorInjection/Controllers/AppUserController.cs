using Entity;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _userServices.GetAllUsersAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> SaveUser(AppUser user)
    {
        try
        {
            var result = await _userServices.SaveUserAsync(user);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> SaveUser(int userId)
    {
        try
        {
            var result = await _userServices.DeleteUserAsync(userId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
