using NoteAI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Contexts;


namespace NoteAI.Data.Repositories;

public class TagRepository : ITagRepository
{
    private readonly MasterContext _context;

    public TagRepository(MasterContext context)
    {
        _context = context;
    }

    public Tag CreateTag(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public Tag GetTagById(int id)
    {
        return _context.Tags.Find(id);
    }

    public IEnumerable<Tag> GetAllTags()
    {
        return _context.Tags.ToList();
    }

    // Get tags for a specific user
    public IEnumerable<Tag> GetTagsByUserId(int userId)
    {
        return _context.Tags.Where(t => t.UserId == userId).ToList();
    }

    // Get tags for a specific group
    public IEnumerable<Tag> GetTagsByGroupId(int groupId)
    {
        return _context.Tags.Where(t => t.GroupId == groupId).ToList();
    }

    public void UpdateTag(Tag tag)
    {
        _context.Entry(tag).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteTag(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }
}