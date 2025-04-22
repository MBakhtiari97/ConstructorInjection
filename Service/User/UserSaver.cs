using DataLayer;
using Entity;

namespace Service.UserServices;

public interface IUserSaver
{
    Task<int> SaveUserAsync(AppUser user);
}

public class UserSaver : IUserSaver
{
    private readonly ApplicationDbContext dbContext;

    public UserSaver(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> SaveUserAsync(AppUser user)
    {
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }
}