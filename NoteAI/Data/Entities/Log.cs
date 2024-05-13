using System.ComponentModel.DataAnnotations;

namespace NoteAI.Data.Entities;

public abstract class Log<TActionEnum>
{
    [Key] public int Id { get; set; }

    public TActionEnum Action { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }

    protected Log(TActionEnum action, DateTime date, int userId, string description)
    {
        Action = action;
        Date = date;
        UserId = userId;
        Description = description;
    }
}