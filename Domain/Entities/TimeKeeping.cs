using Domain.Enums;

namespace Domain.Entities;

public class TimeKeeping
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public TimeKeepingEnum TimeKeepingType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}