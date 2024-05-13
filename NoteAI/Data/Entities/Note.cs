using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities
{
    public class Note
    {
        [Key] public int NoteId { get; set; }

        [Required] [MaxLength(100)] public string Title { get; set; }

        [Required] public string Content { get; set; }

        // Use ICollection<NoteLog> for Logs
        public ICollection<NoteLog> Logs { get; set; }

        // Foreign key relationship to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Many-to-many relationship with Note (self-referential)
        public ICollection<Note> RelatedNotes { get; set; }

        // Many-to-many relationship with Tag
        public ICollection<Tag> Tags { get; set; }

        // One-to-many relationship with FileAttachment
        public ICollection<FileAttachment> Attachments { get; set; }
    }

    // Make NoteLogAction an enum
    public enum NoteLogAction
    {
        Create,
        Update,
        Delete
    }

    public class NoteLog : Log<NoteLogAction>
    {
        // Foreign key relationship to Note
        public int NoteId { get; set; }
        public Note Note { get; set; }

        public NoteLog(NoteLogAction action, DateTime date, int userId, string description, int noteId)
            : base(action, date, userId, description)
        {
            NoteId = noteId;
        }
    }
}