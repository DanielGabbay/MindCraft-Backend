using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Entities;
using NoteAI.Data.Contexts;

namespace NoteAI.Data.Repositories
{
    public class FileAttachmentRepository : IFileAttachmentRepository
    {
        private readonly MasterContext _context;

        public FileAttachmentRepository(MasterContext context)
        {
            _context = context;
        }

        public FileAttachment CreateFileAttachment(FileAttachment fileAttachment)
        {
            _context.FileAttachments.Add(fileAttachment);
            _context.SaveChanges();
            return fileAttachment;
        }

        public IEnumerable<FileAttachment> GetAttachmentsByNoteId(int noteId)
        {
            return _context.FileAttachments.Where(fa => fa.NoteId == noteId).ToList();
        }

        public void DeleteFileAttachment(int id)
        {
            var fileAttachment = _context.FileAttachments.Find(id);
            if (fileAttachment != null)
            {
                _context.FileAttachments.Remove(fileAttachment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<FileAttachment> GetAttachmentsByUserId(int userId)
        {
            return _context.FileAttachments
                .Include(fa => fa.Note)
                .Where(fa => fa.Note.UserId == userId)
                .ToList();
        }

        public FileAttachment GetFileAttachmentById(int id)
        {
            return _context.FileAttachments.Find(id);
        }
    }
}