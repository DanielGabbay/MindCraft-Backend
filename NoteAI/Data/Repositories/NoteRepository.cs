using NoteAI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Contexts; // Add this using

namespace NoteAI.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly MasterContext _context;

        public NoteRepository(MasterContext context)
        {
            _context = context;
        }


        public Note CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public Note GetNoteById(int id)
        {
            return _context.Notes.Find(id);
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public void UpdateNote(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Note> GetNotesByUserId(int userId)
        {
            return _context.Notes.Where(n => n.UserId == userId).ToList();
        }

        public IEnumerable<Note> GetNotesByTagId(int tagId)
        {
            return _context.Notes
                .Include<Note, ICollection<Tag>>(n => n.Tags) // Explicit types for Include
                .Where(n => n.Tags.Any(t => t.TagId == tagId))
                .ToList();
        }
    }
}