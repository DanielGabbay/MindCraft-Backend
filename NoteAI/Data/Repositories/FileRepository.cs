using NoteAI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Contexts; 
using File = NoteAI.Data.Entities.File;


namespace NoteAI.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly MasterContext _context;

        public FileRepository(MasterContext context)
        {
            _context = context;
        }

        public File CreateFile(File file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
            return file;
        }

        public File GetFileById(int id)
        {
            return _context.Files.Find(id);
        }

        public IEnumerable<File> GetFilesByUserId(int userId)
        {
            return _context.Files.Where(f => f.Note.UserId == userId).ToList();
        }

        public void DeleteFile(int id)
        {
            var file = _context.Files.Find(id);
            if (file != null)
            {
                _context.Files.Remove(file);
                _context.SaveChanges();
            }
        }
    }
}