using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BP.Data.Authentication
{
    public class UserAuthentication
    {
        public static bool IsValidUser(User user, BPContext context)
        {
            if (string.IsNullOrEmpty(user?.Username) || string.IsNullOrEmpty(user?.Password))
                return false;
            else
            {
                return context.Users.Any(g => g.Username == user.Username &&
                                            g.Password == ComputeHash(user.Password));
            }

        }

        public static User GetUser(string username, string password, BPContext context)
        {
            return context.Users.FirstOrDefault(g => g.Username == username &&
                                            g.Password == ComputeHash(password));
        }

        public static async Task AddAsync(User user, BPContext context)
        {
            if (string.IsNullOrEmpty(user?.Username) || string.IsNullOrEmpty(user?.Password))
                throw new Exception("Invalid username or password");


            user.Password = ComputeHash(user.Password);
            await context.Users.AddAsync(user);
            context.SaveChanges();            
        }

        public static string ComputeHash(string input)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
