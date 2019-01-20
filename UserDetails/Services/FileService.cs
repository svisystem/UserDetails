using UserDetails.Interfaces;
using UserDetails.Models;
using UserDetails.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserDetails.Services
{
    public class FileService : IFileService
    {
        private FileInfo _file;
        public FileService(IHostingEnvironment env,
            IConfiguration configuration)
        {
            _file = new FileInfo(Path.Combine(env.ContentRootPath, configuration["UserDBFile"]));

            if (!_file.Exists)
                File.WriteAllText(_file.FullName, JsonConvert.SerializeObject(Seed.Users), Encoding.Unicode);
        }

        public IEnumerable<User> GetFile() =>
            JsonConvert.DeserializeObject<IEnumerable<User>>(File.ReadAllText(_file.FullName, Encoding.Unicode));

        public void SetFile(IEnumerable<User> users) =>
            File.WriteAllText(_file.FullName, JsonConvert.SerializeObject(users), Encoding.Unicode);
    }
}
