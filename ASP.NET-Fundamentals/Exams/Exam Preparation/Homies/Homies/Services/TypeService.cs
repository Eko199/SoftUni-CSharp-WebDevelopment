namespace Homies.Services;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class TypeService : ITypeService
{
    private readonly HomiesDbContext context;

    public TypeService(HomiesDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<TypeViewModel>> GetAllAsync()
        => await context.Types.Select(t => new TypeViewModel
        {
            Id = t.Id,
            Name = t.Name
        }).ToArrayAsync();
}