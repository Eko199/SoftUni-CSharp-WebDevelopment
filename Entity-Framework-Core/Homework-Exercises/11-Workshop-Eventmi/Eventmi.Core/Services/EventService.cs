namespace Eventmi.Core.Services;

using Microsoft.EntityFrameworkCore;

using Contracts;
using Data;
using Data.Models;
using Models;

public class EventService : IEventService
{
    private readonly EventmiDbContext _context;

    public EventService(EventmiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventFormModel>> GetAllAsync() 
        => await _context.Events
            .Select(e => new EventFormModel
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                End = e.End,
                Place = e.Place
            })
            .OrderBy(e => e.Start)
            .ToArrayAsync();

    public async Task AddAsync(EventFormModel model)
    {
        await _context.Events.AddAsync(new Event
        {
            Name = model.Name,
            Start = model.Start,
            End = model.End,
            Place = model.Place
        });

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EventFormModel model)
    {
        Event entity = await GetEventByIdAsync(model.Id);

        entity.Name = model.Name;
        entity.Start = model.Start;
        entity.End = model.End;
        entity.Place = model.Place;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _context.Events.Remove(await GetEventByIdAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<EventFormModel> GetByIdAsync(int id)
    {
        Event entity = await GetEventByIdAsync(id);

        return new EventFormModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Start = entity.Start,
            End = entity.End,
            Place = entity.Place
        };
    }

    private async Task<Event> GetEventByIdAsync(int id)
        => await _context.Events.FindAsync(id)
           ?? throw new ArgumentException("Invalid event id!", nameof(id));
}