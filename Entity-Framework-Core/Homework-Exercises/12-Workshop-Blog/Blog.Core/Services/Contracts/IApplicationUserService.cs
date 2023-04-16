namespace Blog.Core.Services.Contracts;

using Models.User;

public interface IApplicationUserService
{
    Task<bool> UsernameExistsAsync(string username);

    Task<bool> EmailExistsAsync(string email);

    Task CreateUserAsync(RegisterViewModel model);

    Task<string?> GetIdByUsernameAsync(string username);

    Task<string?> GetUsernameByIdAsync(string id);

    Task<bool> ValidateLoginInfoAsync(LoginViewModel model);
}