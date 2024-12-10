using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Login;

public class LoginRequestDto
{
    [Required(ErrorMessage = "O campo Username é obrigatório.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório.")]
    public string Password { get; set; }
}