using UserDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Repositories
{
    public static class Seed
    {
        public static IEnumerable<User> Users { get; set; } = new List<User>
        {
            new User()
            {
                Id = 0,
                FirstName = "István",
                SurName = "Nagy",
                BirthDate = new DateTime(1978, 5, 20),
                BirthPlace = "Budapest",
                Email = "nagy.istvan@gmail.com",
                Phone = "+3612345678",
                UserName = "I",
                Password = "12345"
            },
            new User()
            {
                Id = 1,
                FirstName = "Lajos",
                SurName = "Kiss",
                BirthDate = new DateTime(1985, 9, 3),
                BirthPlace = "Szigetszentmiklós",
                Email = "lali45@outlook.com",
                Phone = "+3618976543",
                UserName = "lali",
                Password = "lalika"
            },
            new User()
            {
                Id = 2,
                FirstName = "Béla",
                SurName = "Kovács",
                BirthDate = new DateTime(1951, 7, 28),
                BirthPlace = "Budapest",
                Email = "nagy.istvan@gmail.com",
                Phone = "+367089123456",
                UserName = "bela",
                Password = "password"
            }
        };
    }
}
