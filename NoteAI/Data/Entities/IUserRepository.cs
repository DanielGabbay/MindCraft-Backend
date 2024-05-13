using NoteAI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Contexts;

namespace NoteAI.Data.Entities
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUsersByGroupId(int groupId);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}


