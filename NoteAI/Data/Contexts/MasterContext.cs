using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Entities;

// using Task = NoteAI.Data.Entities.Task;
// using File = NoteAI.Data.Entities.File;

namespace NoteAI.Data.Contexts;

public class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    // Data Sources in the database:
    // public DbSet<File> Files { get; set; }
    // public DbSet<Note> Notes { get; set; }


    // public DbSet<Task> Tasks { get; set; }
}