namespace Service.UserAddressServices;

public interface IUserAddressServices
{
    Task<int> DeleteUserAddressAsync(int userAddressId);
}

public class UserAddressServices : IUserAddressServices
{
    private readonly IUserAddressRemover _userAddressRemover;

    public UserAddressServices(IUserAddressRemover userAddressRemover)
    {
        _userAddressRemover = userAddressRemover;
    }

    public async Task<int> DeleteUserAddressAsync(int userAddressId)
        => await _userAddressRemover.DeleteUserAddressAsync(userAddressId);
}