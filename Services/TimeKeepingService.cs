using Domain.DTOs.TimeKeeping;
using Domain.Entities;
using Domain.Interfaces.Services;
using Infra.Persistance;

namespace Services;

public class TimeKeepingService : ITimeKeepingService
{
    private readonly AppDbContext _dbContext;

    public TimeKeepingService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RegisterTimeResultDto RegisterTime(Guid userId, TimeKeepingRequestDto request)
    {
        var time = new TimeKeeping() {
            Id = Guid.NewGuid(),
            UserId = userId,
            Date = request.Date,
            TimeKeepingType = request.TimeKeepingType,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _dbContext.TimeKeepings.Add(time);
        _dbContext.SaveChanges();

        return new RegisterTimeResultDto { Success = true };
    }

    public List<TimeKeepingResponseDto> GetTimeHistory(Guid userId, int? month, int? year)
    {
        var query = _dbContext.TimeKeepings.Where(t => t.UserId == userId && t.Date.Month == month && t.Date.Year == year);

        return query
            .OrderBy(t => t.Date)
            .Select(t => new TimeKeepingResponseDto()
            {
                Date = t.Date,
                Type = t.TimeKeepingType
            })
            .ToList();
    }
}