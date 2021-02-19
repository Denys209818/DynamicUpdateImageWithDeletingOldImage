using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Helpers
{
    public class PasswordManager
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
