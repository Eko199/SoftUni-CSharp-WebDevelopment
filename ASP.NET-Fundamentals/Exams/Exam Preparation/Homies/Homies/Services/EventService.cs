namespace Homies.Services;

using Contracts;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Models;

public class EventService : IEventService
{
    private readonly HomiesDbContext context;

    public EventService(HomiesDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<EventViewModel>> GetAllAsync()
        => await context.Events.Select(e => new EventViewModel
        {
            Id = e.Id,
            Name = e.Name,
            Organiser = e.Organiser.UserName,
            Start = e.Start.ToString(DataConstants.DateFormat),
            Type = e.Type.Name
        }).ToListAsync();

    public async Task<IEnumerable<EventViewModel>> GetAllJoinedAsync(string userId) 
        => await context.Events
            .Where(e => e.EventParticipants.Any(ep => ep.HelperId == userId))
            .Select(e => new EventViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(DataConstants.DateFormat),
                Type = e.Type.Name
            }).ToListAsync();

    public async Task<bool> JoinAsync(string userId, int eventId)
    {
        if (await context.EventsParticipants.AnyAsync(ep => ep.EventId == eventId && ep.HelperId == userId))
        {
            return false;
        }
        
        await context.EventsParticipants.AddAsync(new EventParticipant
        {
            EventId = eventId,
            HelperId = userId
        });

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LeaveAsync(string userId, int eventId)
    {
        var mappingToRemove = await context.EventsParticipants
            .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == eventId);

        if (mappingToRemove is null)
        {
            return false;
        }

        context.EventsParticipants.Remove(mappingToRemove);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task AddAsync(EventFormViewModel model, string userId)
    {
        await context.Events.AddAsync(new Event
        {
            Name = model.Name,
            Description = model.Description,
            OrganiserId = userId,
            CreatedOn = DateTime.Now,
            Start = model.Start,
            End = model.End,
            TypeId = model.TypeId
        });

        await context.SaveChangesAsync();
    }

    public async Task EditAsync(int id, EventFormViewModel model)
    {
        Event entity = await context.Events.FindAsync(id)
            ?? throw new ApplicationException("Invalid event id!");

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Start = model.Start;
        entity.End = model.End;
        entity.TypeId = model.TypeId;

        await context.SaveChangesAsync();
    }

    public async Task<EventDetailsViewModel?> GetDetailsByIdAsync(int id) 
        => await context.Events
            .Select(e => new EventDetailsViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Start = e.Start.ToString(DataConstants.DateFormat),
                End = e.End.ToString(DataConstants.DateFormat),
                Organiser = e.Organiser.UserName,
                CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                Type = e.Type.Name
            })
            .SingleOrDefaultAsync(e => e.Id == id);

    public async Task<EventEditViewModel?> GetFormModelByIdAsync(int id)
    {
        var entity = await context.Events.FindAsync(id);

        return entity is null
            ? null
            : new EventEditViewModel
            {
                Name = entity.Name,
                Description = entity.Description,
                Start = entity.Start,
                End = entity.End,
                OrganiserId = entity.OrganiserId,
                TypeId = entity.TypeId
            };
    }
}