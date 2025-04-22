using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Service.UserServices;

public interface IUserRemover
{
    Task<int> DeleteUserAsync(int userId);
}

public class UserRemover : IUserRemover
{
    private readonly ApplicationDbContext dbContext;
    private readonly IUserServices _userServices;

    public UserRemover(ApplicationDbContext dbContext, IUserServices userServices)
    {
        this.dbContext = dbContext;
        this._userServices = userServices;
    }

    public async Task<int> DeleteUserAsync(int userId)
    {
        var user = await _userServices.GetUserAsync(userId);
        if (user == null)
            throw new Exception("User not found");
        dbContext.AppUser.Remove(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }
}