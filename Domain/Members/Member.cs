using Domain.Accounts;
using Infrastructure.Infrastructure;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Members
{
    public class Member : IAggregateRoot
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<MemberAccount> Accounts { get; set; }

        public void SetPassword(string password)
        {
            PasswordHash = GetPasswordHash(password);
        }

        public bool IsEquealPassword(string password)
        {
            var hash = GetPasswordHash(password);
            return PasswordHash.Equals(hash);
        }

        private string GetPasswordHash(string pwd)
        {
            // TODO add Md5
            var data = Encoding.ASCII.GetBytes(pwd + "VeryLongSalt");
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }

            return hash;
        }

        public int Key => Id;
    }
}
