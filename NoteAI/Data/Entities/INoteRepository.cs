namespace NoteAI.Data.Entities;

public interface INoteRepository
{
    Note CreateNote(Note note);
    Note GetNoteById(int id);
    IEnumerable<Note> GetAllNotes();
    void UpdateNote(Note note);
    void DeleteNote(int id);
    IEnumerable<Note> GetNotesByUserId(int userId);
    IEnumerable<Note> GetNotesByTagId(int tagId);
}