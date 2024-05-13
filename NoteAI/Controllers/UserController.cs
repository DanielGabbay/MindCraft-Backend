using Microsoft.AspNetCore.Mvc;
using NoteAI.Data.Entities;

namespace NoteAI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // POST: api/user
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Hash the user's password before storing it (using bcrypt or similar)
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

        var createdUser = _userRepository.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    // GET: api/user
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return Ok(users);
    }

    // GET: api/user/5
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // PUT: api/user/5
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != user.Id)
        {
            return BadRequest();
        }

        _userRepository.UpdateUser(user);
        return NoContent();
    }

    // DELETE: api/user/5
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
        return NoContent();
    }

    // GET: api/user/group/5
    [HttpGet("group/{groupId}")]
    public IActionResult GetUsersByGroupId(int groupId)
    {
        var users = _userRepository.GetUsersByGroupId(groupId);
        return Ok(users);
    }
}