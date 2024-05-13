using Microsoft.AspNetCore.Mvc;
using NoteAI.Data.Entities;

namespace NoteAI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileAttachmentController : ControllerBase
{
    // Inject your FileAttachment repository/service (e.g., IFileAttachmentRepository)
    private readonly IFileAttachmentRepository _fileAttachmentRepository;

    public FileAttachmentController(IFileAttachmentRepository fileAttachmentRepository)
    {
        _fileAttachmentRepository = fileAttachmentRepository;
    }

    // POST: api/fileattachment
    [HttpPost]
    public IActionResult AttachFileToNote(int noteId, int fileId)
    {
        var fileAttachment = new FileAttachment
        {
            NoteId = noteId,
            FileId = fileId
            // May need adjustments based on your actual FileAttachment entity
        };

        _fileAttachmentRepository.CreateFileAttachment(fileAttachment);
        return CreatedAtAction(nameof(GetFileAttachmentById), new { id = fileAttachment.FileAttachmentId },
            fileAttachment);
    }

    // GET: api/fileattachment/note/5
    [HttpGet("note/{noteId}")]
    public IActionResult GetAttachmentsByNoteId(int noteId)
    {
        var attachments = _fileAttachmentRepository.GetAttachmentsByNoteId(noteId);
        return Ok(attachments);
    }

    // DELETE: api/fileattachment/5
    [HttpDelete("{id}")]
    public IActionResult DeleteAttachmentById(int id)
    {
        _fileAttachmentRepository.DeleteFileAttachment(id);
        return NoContent();
    }

    // GET: api/fileattachment/user/5
    [HttpGet("user/{userId}")]
    public IActionResult GetAttachmentsByUserId(int userId)
    {
        var attachments = _fileAttachmentRepository.GetAttachmentsByUserId(userId);
        return Ok(attachments);
    }

    [HttpGet("{id}")]
    public IActionResult GetFileAttachmentById(int id)
    {
        var attachment = _fileAttachmentRepository.GetFileAttachmentById(id);
        if (attachment == null)
        {
            return NotFound();
        }

        return Ok(attachment);
    }
}