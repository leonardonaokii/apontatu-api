using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.TimeKeeping;

public class TimeKeepingRequestDto
{
    [Required(ErrorMessage = "A data é obrigatória.")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "A tipo de marcação do ponto é obrigatório.")]
    public TimeKeepingEnum TimeKeepingType { get; set; }
}