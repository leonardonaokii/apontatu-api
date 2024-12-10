using Domain.DTOs.TimeKeeping;

namespace Domain.Interfaces.Services;

public interface ITimeKeepingService
{
    RegisterTimeResultDto RegisterTime(Guid userId, TimeKeepingRequestDto request);
    List<TimeKeepingResponseDto> GetTimeHistory(Guid userId, int? month, int? year);
}