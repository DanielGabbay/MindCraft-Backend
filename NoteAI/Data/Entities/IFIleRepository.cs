using File = NoteAI.Data.Entities.File;

namespace NoteAI.Data.Entities;
public interface IFileRepository
{
    File CreateFile(File file);
    File GetFileById(int id);
    IEnumerable<File> GetFilesByUserId(int userId);
    void DeleteFile(int id);
}