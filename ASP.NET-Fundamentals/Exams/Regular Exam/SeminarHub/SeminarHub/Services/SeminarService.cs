namespace SeminarHub.Services;

using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Models.Seminar;

public class SeminarService : ISeminarService
{
    private readonly SeminarHubDbContext context;

    public SeminarService(SeminarHubDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<SeminarViewModel>> GetAllAsync()
        => await context.Seminars.Select(s => new SeminarViewModel
        {
            Id = s.Id,
            Topic = s.Topic,
            Lecturer = s.Lecturer,
            Category = s.Category.Name,
            DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
            Organizer = s.Organizer.UserName
        }).ToListAsync();

    public async Task<IEnumerable<SeminarViewModel>> GetAllJoinedAsync(string userId) 
        => await context.Seminars
            .Where(s => s.SeminarParticipants.Any(sp => sp.ParticipantId == userId))
            .Select(s => new SeminarViewModel
            {
                Id = s.Id,
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Category = s.Category.Name,
                DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
                Organizer = s.Organizer.UserName
            })
            .ToListAsync();

    public async Task AddAsync(SeminarFormModel seminar)
    {
        await context.Seminars.AddAsync(new Seminar
        {
            Topic = seminar.Topic,
            Lecturer = seminar.Lecturer,
            Details = seminar.Details,
            DateAndTime = seminar.DateAndTime,
            Duration = seminar.Duration,
            CategoryId = seminar.CategoryId,
            OrganizerId = seminar.OrganiserId
        });

        await context.SaveChangesAsync();
    }

    public async Task EditAsync(int id, SeminarFormModel seminar)
    {
        Seminar entity = await context.Seminars.FindAsync(id)
                         ?? throw new ApplicationException("Invalid seminar id!");

        entity.Topic = seminar.Topic;
        entity.Lecturer = seminar.Lecturer;
        entity.Details = seminar.Details;
        entity.DateAndTime = seminar.DateAndTime;
        entity.Duration = seminar.Duration;
        entity.CategoryId = seminar.CategoryId;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var seminarParticipants = await context.SeminarParticipants
            .Where(sp => sp.SeminarId == id)
            .ToListAsync();

        context.SeminarParticipants.RemoveRange(seminarParticipants);

        var seminar = await context.Seminars.FindAsync(id)
            ?? throw new ApplicationException("Invalid seminar id!");

        context.Seminars.Remove(seminar);
        await context.SaveChangesAsync();
    }

    public async Task<SeminarDetailsViewModel?> GetDetailsByIdAsync(int id)
        => await context.Seminars.Select(s => new SeminarDetailsViewModel
        {
            Id = s.Id,
            Topic = s.Topic,
            Lecturer = s.Lecturer,
            Category = s.Category.Name,
            DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
            Organizer = s.Organizer.UserName,
            Duration = s.Duration,
            Details = s.Details,
        }).SingleOrDefaultAsync(s => s.Id == id);

    public async Task<SeminarFormModel?> GetFormModelByIdAsync(int id)
    {
        Seminar? seminar = await context.Seminars.FindAsync(id);

        return seminar == null
            ? null
            : new SeminarFormModel
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime,
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId,
                OrganiserId = seminar.OrganizerId
            };
    }

    public async Task<SeminarDeleteViewModel?> GetDeleteModelByIdAsync(int id)
    {
        Seminar? seminar = await context.Seminars.FindAsync(id);

        return seminar == null
            ? null
            : new SeminarDeleteViewModel
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime,
                OrganizerId = seminar.OrganizerId
            };
    }

    public async Task<bool> JoinAsync(int seminarId, string userId)
    {
        if (await context.SeminarParticipants.AnyAsync(sp => sp.SeminarId == seminarId && sp.ParticipantId == userId))
        {
            return false;
        }

        await context.SeminarParticipants.AddAsync(new SeminarParticipant
        {
            SeminarId = seminarId,
            ParticipantId = userId
        });

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LeaveAsync(int seminarId, string userId)
    {
        SeminarParticipant? participation = await context.SeminarParticipants
            .SingleOrDefaultAsync(sp => sp.SeminarId == seminarId && sp.ParticipantId == userId);

        if (participation == null)
        {
            return false;
        }

        context.SeminarParticipants.Remove(participation);
        await context.SaveChangesAsync();

        return true;
    }
}