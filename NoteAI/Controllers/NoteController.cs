using Microsoft.AspNetCore.Mvc;
using NoteAI.Data.Entities; // Assuming your entities are in this namespace

namespace NoteAI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController : ControllerBase
{
    // Inject your Note repository or service here (e.g., INoteRepository)
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    // POST: api/note
    [HttpPost]
    public IActionResult CreateNote([FromBody] Note note) 
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        var createdNote = _noteRepository.CreateNote(note);
        return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.NoteId }, createdNote);
    }

    // GET: api/note
    [HttpGet]
    public IActionResult GetAllNotes()
    {
        var notes = _noteRepository.GetAllNotes();
        return Ok(notes);
    }

    // GET: api/note/5
    [HttpGet("{id}")]
    public IActionResult GetNoteById(int id)
    {
        var note = _noteRepository.GetNoteById(id);
        if (note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }

    // PUT: api/note/5
    [HttpPut("{id}")]
    public IActionResult UpdateNote(int id, [FromBody] Note note)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != note.NoteId)
        {
            return BadRequest();
        }

        _noteRepository.UpdateNote(note);
        return NoContent();
    }

    // DELETE: api/note/5
    [HttpDelete("{id}")]
    public IActionResult DeleteNote(int id)
    {
        _noteRepository.DeleteNote(id);
        return NoContent();
    }

    // GET: api/note/user/5
    [HttpGet("user/{userId}")]
    public IActionResult GetNotesByUserId(int userId)
    {
        var notes = _noteRepository.GetNotesByUserId(userId);
        return Ok(notes);
    }

    // GET: api/note/tag/5
    [HttpGet("tag/{tagId}")]
    public IActionResult GetNotesByTagId(int tagId)
    {
        var notes = _noteRepository.GetNotesByTagId(tagId);
        return Ok(notes);
    }
}