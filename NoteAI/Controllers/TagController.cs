using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NoteAI.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace NoteAI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagRepository _tagRepository;

    public TagController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }


    // POST: api/tag
    [Authorize] // Assuming you have authentication in place
    [HttpPost]
    public IActionResult CreateTag([FromBody] TagCreateDto tagDto)
    {
        // Check if the user is authorized to create a tag for the given user or group 
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized(); // User not authenticated
        }

        // Get the currently logged-in user's Id (You'll need to implement this)
        int currentUserId = int.Parse(userId);

        if (tagDto.UserId != null && tagDto.UserId != currentUserId)
        {
            return Forbid(); // Not authorized to create a tag for another user
        }

        // Similarly, check for Group authorization 
        // if (tagDto.GroupId != null && !IsUserInGroup(currentUserId, tagDto.GroupId)) { ... }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Tag newTag;
        if (tagDto.UserId != null)
        {
            newTag = new UserTag(tagDto.Name, (int)tagDto.UserId);
        }
        else if (tagDto.GroupId != null)
        {
            newTag = new GroupTag(tagDto.Name, (int)tagDto.GroupId);
        }
        else
        {
            return BadRequest("Either UserId or GroupId must be provided.");
        }

        _tagRepository.CreateTag(newTag);
        return CreatedAtAction(nameof(GetTagById), new { id = newTag.TagId }, newTag);
    }

    // GET: api/tag/5
    [HttpGet("{id}")]
    public IActionResult GetTagById(int id)
    {
        var tag = _tagRepository.GetTagById(id);
        if (tag == null)
        {
            return NotFound();
        }

        return Ok(tag);
    }
}

// DTO for tag creation (can be adjusted based on your needs)
public class TagCreateDto
{
    [Required] public string Name { get; set; }

    public int? UserId { get; set; }
    public int? GroupId { get; set; }
}