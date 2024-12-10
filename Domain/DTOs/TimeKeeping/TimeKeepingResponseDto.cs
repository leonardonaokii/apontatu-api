using Domain.Enums;

namespace Domain.DTOs.TimeKeeping;

public class TimeKeepingResponseDto
{
    public DateTime Date { get; set; }
    public TimeKeepingEnum Type { get; set; }
}