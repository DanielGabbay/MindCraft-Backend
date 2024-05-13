using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public class User
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string Username { get; set; }


    public string Password { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Role { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshTokenExpiryTime { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string DeletedAt { get; set; }
}