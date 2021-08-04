using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Demo.Models;

namespace JWT.Demo.Data
{
    abstract public class DataAccess
    {
        public static JWTDemoDbContext _context { get; set; }

        public static bool Authorize(string username, string password)
        {
                try
                {
                    if (_context.Users.FirstOrDefault(userInDB => userInDB.Username == username && userInDB.Password == password) == null)
                        return false;

                    return true;

                }
                catch
                {
                    return false;
                }
        }

    }
}
