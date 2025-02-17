using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Application.Helpers
{
    public static class RandomDataCreator
    {
        public static string GeneratePassword(int length)
        {
            const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var password = new StringBuilder();

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] byteBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(byteBuffer);
                    uint num = BitConverter.ToUInt32(byteBuffer, 0);
                    password.Append(AllowedChars[(int)(num % (uint)AllowedChars.Length)]);
                }
            }

            return password.ToString();
        }
    }
}