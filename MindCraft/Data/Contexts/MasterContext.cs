using Microsoft.EntityFrameworkCore;

namespace MindCraft.Data.Contexts;

public class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {
    }

    // Add DbSet properties for your entities:
    // public DbSet<User> Users { get; set; }
    // public DbSet<Note> Notes { get; set; }
    // public DbSet<Tag> Tags { get; set; }
    // public DbSet<UserTag> UserTags { get; set; }
    // public DbSet<SystemTag> SystemTags { get; set; }
    // public DbSet<GroupTag> GroupTags { get; set; }
    // public DbSet<File> Files { get; set; }
    // public DbSet<FileAttachment> FileAttachments { get; set; }
    // public DbSet<UsersGroup> UsersGroups { get; set; }
    //

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>()
    //         .HasMany(u => u.Groups)
    //         .WithMany(g => g.Users)
    //         .UsingEntity<Dictionary<string, object>>(
    //             "UserGroup",
    //             j => j.HasOne<UsersGroup>().WithMany().HasForeignKey("GroupId"),
    //             j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
    //         );
    //
    //     modelBuilder.Entity<Note>()
    //         .HasMany(n => n.Tags)
    //         .WithMany(t => t.Notes)
    //         .UsingEntity<Dictionary<string, object>>(
    //             "NoteTag",
    //             j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
    //             j => j.HasOne<Note>().WithMany().HasForeignKey("NoteId")
    //         );
    //
    //     modelBuilder.Entity<User>().HasMany(u => u.Groups).WithMany(g => g.Users);
    //     modelBuilder.Entity<Tag>().HasMany(t => t.Notes).WithMany(n => n.Tags);
    // }
}