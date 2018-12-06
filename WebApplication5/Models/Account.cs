using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public AccountStatus Status { get; set; }
        public void GenerateSalt()
        {
            this.Salt = Guid.NewGuid().ToString();
        }
        public void EncryptPassword()
        {
            this.Password += this.Salt;
            var algorithm = MD5.Create();
            var hashPassword = algorithm.ComputeHash(Encoding.UTF8.GetBytes(this.Password));
            this.Password = Convert.ToBase64String(hashPassword);
        }
    }
   
    public enum AccountStatus
    {
        Activated = 1,
        Deactivated = 0
    }
}
