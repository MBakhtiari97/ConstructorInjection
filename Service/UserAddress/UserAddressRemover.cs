using DataLayer;

namespace Service.UserAddressServices;

public interface IUserAddressRemover
{
    Task<int> DeleteUserAddressAsync(int userAddressId);
}

public class UserAddressRemover : IUserAddressRemover
{
    private readonly ApplicationDbContext dbContext;

    public UserAddressRemover(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> DeleteUserAddressAsync(int userAddressId)
    {
        var userAddress = await dbContext.UserAddress.FindAsync(userAddressId);
        if (userAddress == null)
            throw new Exception("User not found");
        dbContext.UserAddress.Remove(userAddress);
        await dbContext.SaveChangesAsync();
        return userAddress.Id;
    }
}