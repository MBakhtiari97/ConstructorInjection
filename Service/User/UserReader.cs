using DataLayer;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Service.UserServices;

public interface IUserReader
{
    Task<AppUser?> GetUserAsync(int userId);
    Task<IEnumerable<AppUser>?> GetAllUsersAsync();
}

public class UserReader : IUserReader
{
    private readonly ApplicationDbContext dbContext;

    public UserReader(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AppUser>?> GetAllUsersAsync()
    {
        return await dbContext.AppUser
        .ToListAsync();
    }

    public async Task<AppUser?> GetUserAsync(int userId)
    {
        return await dbContext.AppUser
            .FindAsync(userId);
    }
}