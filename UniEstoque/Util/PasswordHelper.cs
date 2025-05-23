﻿using System.Security.Cryptography;
using System.Text;

namespace UniEstoque.Util
{
    public static class PasswordHelper
    {
        public static string HashPassword(string senha) 
        {
            using (SHA256 sha256 = SHA256.Create()) 
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                foreach(byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
