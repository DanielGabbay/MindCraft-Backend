using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public class UsersGroup
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    public string Description { get; set; }

    // many-to-many relationship between User and UsersGroup entities
    public ICollection<User> Users { get; set; } 

    // many-to-many relationship between Tag and UsersGroup entities (for group sharing)
    public ICollection<Tag> Tags { get; set; }
    
    
}