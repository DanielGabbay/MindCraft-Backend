using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

// Tag connects to Note/File and is used to categorize notes:
// There are 3 types of tags: User Tags, System Tags, Group Tags
// User Tags are created by the user and are unique to the user
// System Tags are created by the system and are shared across all users
// Group Tags are created by group's users and are shared across the group

public abstract class Tag
{
    [Key] public int TagId { get; set; }

    [MaxLength(50)]
    [MinLength(1)]
    [Required]
    public string? Name { get; set; } // Make it nullable if it can be null


    public int? UserId { get; set; }
    public User User { get; set; }

    // many-to-many relationship between Tag and UsersGroup entities (for group sharing)
    public int? GroupId { get; set; }
    public UsersGroup Group { get; set; }

    // many-to-many relationship between Tag and Note entities
    public ICollection<Note> Notes { get; set; }
}

public class UserTag : Tag
{
    // Parameterless constructor for EF Core
    public UserTag()
    {
    }

    public UserTag(string name, int userId)
    {
        Name = name;
        UserId = userId;
    }
}

public class SystemTag : Tag
{
    // Parameterless constructor for EF Core
    public SystemTag()
    {
    }

    public SystemTag(string name)
    {
        Name = name;
    }
}

public class GroupTag : Tag
{
    // Parameterless constructor for EF Core
    public GroupTag()
    {
    }

    public GroupTag(string name, int groupId)
    {
        Name = name;
        GroupId = groupId;
    }
}

// TagService is used to manage tags
// Controller operations:
// - POST - Create a tag (UserTag) for the user (User) or group (Group) 
// - GET - Get all tags for the user or group
// - PUT - Update a tag for the user or group (only creator can update)
// - DELETE - Delete a tag for the user or group (only creator can delete)