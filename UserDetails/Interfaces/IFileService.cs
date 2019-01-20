using UserDetails.Models;
using System.Collections.Generic;

namespace UserDetails.Interfaces
{
    public interface IFileService
    {
        IEnumerable<User> GetFile();

        void SetFile(IEnumerable<User> users);
    }
}
