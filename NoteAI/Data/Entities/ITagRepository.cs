namespace NoteAI.Data.Entities;

public interface ITagRepository
{
    Tag CreateTag(Tag tag);
    Tag GetTagById(int id);
    IEnumerable<Tag> GetAllTags();
    IEnumerable<Tag> GetTagsByUserId(int userId);
    IEnumerable<Tag> GetTagsByGroupId(int groupId);
    void UpdateTag(Tag tag);
    void DeleteTag(int id);
    
}