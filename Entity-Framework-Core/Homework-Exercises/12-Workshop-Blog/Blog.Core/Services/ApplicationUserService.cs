namespace Blog.Core.Services;

using System.Security.Cryptography;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Models.User;
using Contracts;
using Data;
using Data.Models;

public class ApplicationUserService : IApplicationUserService
{
    private readonly BlogDbContext context;

    public ApplicationUserService(BlogDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> UsernameExistsAsync(string username) 
        => await context.ApplicationUsers.AnyAsync(u => u.UserName == username);

    public async Task<bool> EmailExistsAsync(string email)
        => await context.ApplicationUsers.AnyAsync(u => u.Email == email);

    public async Task CreateUserAsync(RegisterViewModel model)
    {
        string passwordSalt = GeneratePasswordSalt();
        string password = ComputeSha256Hash(model.Password, passwordSalt);

        await context.ApplicationUsers.AddAsync(new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
            Password = password,
            PasswordSalt = passwordSalt
        });

        await context.SaveChangesAsync();
    }

    public async Task<string?> GetIdByUsernameAsync(string username) 
        =>  (await context.ApplicationUsers
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserName == username))?.Id;

    public async Task<string?> GetUsernameByIdAsync(string id) 
        => (await context.ApplicationUsers
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == id))?.UserName;

    public async Task<bool> ValidateLoginInfoAsync(LoginViewModel model)
    {
        ApplicationUser? user = await context.ApplicationUsers
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.UserName == model.UserName);

        if (user == null) return false;

        return user.Password == ComputeSha256Hash(model.Password, user.PasswordSalt);
    }

    private static string GeneratePasswordSalt()
    {
        var bytes = new byte[128 / 8];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }

    private static string ComputeSha256Hash(string rawData, string salt)
    {
        // Create a SHA256
        using var sha256Hash = SHA256.Create();

        // ComputeHash - returns byte array
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string
        var sb = new StringBuilder();
        foreach (var b in bytes)
        {
            sb.Append(b.ToString("x2"));
        }

        sb.Append(salt);
        return sb.ToString();
    }
}