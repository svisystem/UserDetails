using UserDetails.Interfaces;
using UserDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IFileService _fileService;

        private List<User> _users;

        public UserRepository(IFileService fileService)
        {
            _fileService = fileService;
            _users = _fileService.GetFile().ToList();
        }

        public void AddSingle(User user)
        {
            User latest = _users.OrderByDescending(users => users.Id).FirstOrDefault();
            user.Id = latest == null ? 0 : latest.Id + 1;
            _users.Add(user);
            _fileService.SetFile(_users);
        }

        public User GetSingleById(int id) =>
            _users.SingleOrDefault(u => u.Id == id);

        public User GetSingleByUserName(string name) =>
            _users.SingleOrDefault(u => u.UserName == name);

        public IEnumerable<User> GetAll() =>
            _users.OrderBy(u => u.Id);

        public void UdateSingle(User user)
        {
            _users.Remove(_users.Single(member => member.Id == user.Id));
            _users.Add(user);
            _fileService.SetFile(_users);
        }

        public void Remove(int user)
        {
            User selected = _users.SingleOrDefault(u => u.Id == user);
            if (selected != null)
            {
                _users.Remove(selected);
                _fileService.SetFile(_users);
            }
        }
    }
}
