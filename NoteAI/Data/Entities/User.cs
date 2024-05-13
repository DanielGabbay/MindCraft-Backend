using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public class User
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string Username { get; set; }

    public string PasswordHash { get; set; } // Hash passwords!

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    public UserRole Role { get; set; } = UserRole.User;
    public string Token { get; set; } 
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; } 
    public string PasswordSalt { get; set; } // Salt for password hashing


    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } 
    public DateTime? DeletedAt { get; set; }

    // Many-to-many relationship between User and UsersGroup entities
    public ICollection<UsersGroup> Groups { get; set; } = new List<UsersGroup>(); 
}

public enum UserRole
{
    Admin,
    User,
    Guest
}