using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Contexts;
using NoteAI.Data.Entities;

namespace NoteAI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MasterContext _context;

        public UserRepository(MasterContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        // UserRepository.cs
        public IEnumerable<User> GetUsersByGroupId(int groupId)
        {
            return _context.Users
                .Where(u => u.Groups.Any(g => g.Id == groupId))
                .ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}