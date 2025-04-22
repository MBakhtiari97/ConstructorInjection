using Entity;

namespace Service.UserServices;

public interface IUserServices
{
    Task<int> SaveUserAsync(AppUser user);
    Task<AppUser?> GetUserAsync(int userId);
    Task<int> DeleteUserAsync(int userId);
    Task<IEnumerable<AppUser>?> GetAllUsersAsync();
}

public class UserServices : IUserServices
{
    private readonly IUserReader _userReader;
    private readonly IUserSaver _userSaver;
    private readonly IUserRemover _userRemover;

    public UserServices(IUserReader userReader, IUserSaver userSaver, IUserRemover userRemover)
    {
        _userReader = userReader;
        _userSaver = userSaver;
        _userRemover = userRemover;
    }

    public async Task<int> DeleteUserAsync(int userId)
        => await _userRemover.DeleteUserAsync(userId);

    public async Task<IEnumerable<AppUser>?> GetAllUsersAsync()
        => await _userReader.GetAllUsersAsync();

    public async Task<AppUser?> GetUserAsync(int userId)
        => await _userReader.GetUserAsync(userId);

    public async Task<int> SaveUserAsync(AppUser user)
        => await _userSaver.SaveUserAsync(user);
}