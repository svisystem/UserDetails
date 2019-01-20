using UserDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Interfaces
{
    public interface IUserRepository
    {
        void AddSingle(User user);

        void UdateSingle(User user);

        User GetSingleById(int id);

        User GetSingleByUserName(string name);

        IEnumerable<User> GetAll();

        void Remove(int user);
    }
}
