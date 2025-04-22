using DataLayer;

namespace Service.UserServices;

public interface IUserRemover
{
    Task<int> DeleteUserAsync(int userId);
}

public class UserRemover : IUserRemover
{
    private readonly ApplicationDbContext dbContext;

    public UserRemover(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> DeleteUserAsync(int userId)
    {
        var user = await dbContext.AppUser.FindAsync(userId);
        if (user == null)
            throw new Exception("User not found");
        dbContext.AppUser.Remove(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }
}