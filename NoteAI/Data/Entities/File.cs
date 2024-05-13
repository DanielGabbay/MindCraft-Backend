using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public class File
{
    [Key] public int FileId { get; set; }
    [Required] public string FileName { get; set; }
    [Required] public byte[] FileData { get; set; }

    public int? NoteId { get; set; } // Make NoteId nullable to support orphaned files
    public Note Note { get; set; }
    
    public string ContentType { get; set; } // Add ContentType property
    public DateTime UploadDate { get; set; } // Add UploadDate property
}