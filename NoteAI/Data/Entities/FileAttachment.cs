using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public class FileAttachment
{
    [Key] public int FileAttachmentId { get; set; }

    [Required] public string FileName { get; set; }

    [Required] public byte[] FileData { get; set; }

    public int NoteId { get; set; }
    public Note Note { get; set; }
    
    public int FileId { get; set; }
    public File File { get; set; } 
}