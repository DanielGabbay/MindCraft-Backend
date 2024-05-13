namespace NoteAI.Data.Entities;

public interface IFileAttachmentRepository
{
    FileAttachment CreateFileAttachment(FileAttachment fileAttachment);
    IEnumerable<FileAttachment> GetAttachmentsByNoteId(int noteId);
    void DeleteFileAttachment(int id);
    IEnumerable<FileAttachment> GetAttachmentsByUserId(int userId);
    FileAttachment GetFileAttachmentById(int id);
}