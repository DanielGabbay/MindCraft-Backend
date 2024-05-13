using Microsoft.AspNetCore.Mvc;
using NoteAI.Data.Entities;

namespace NoteAI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    // Inject your File repository/service (e.g., IFileRepository)
    private readonly IFileRepository _fileRepository;

    public FileController(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    // POST: api/file
    [HttpPost]
    public IActionResult UploadFile([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            var fileData = memoryStream.ToArray();

            var newFile = new NoteAI.Data.Entities.File // Fully qualify the File entity
            {
                FileName = file.FileName,
                FileData = fileData
                // Consider adding other properties like ContentType
            };

            _fileRepository.CreateFile(newFile);
            return CreatedAtAction(nameof(GetFileById), new { id = newFile.FileId }, newFile);
        }
    }

    // GET: api/file/user/5 
    [HttpGet("user/{userId}")]
    public IActionResult GetFilesByUserId(int userId)
    {
        var files = _fileRepository.GetFilesByUserId(userId);
        return Ok(files);
    }

    // GET: api/file/5
    [HttpGet("{id}")]
    public IActionResult GetFileById(int id)
    {
        var file = _fileRepository.GetFileById(id);
        if (file == null)
        {
            return NotFound();
        }

        // Consider setting the Content-Type header based on file.ContentType
        return File(file.FileData, "application/octet-stream", file.FileName);
    }

    // DELETE: api/file/5
    [HttpDelete("{id}")]
    public IActionResult DeleteFile(int id)
    {
        _fileRepository.DeleteFile(id);
        return NoContent();
    }
}