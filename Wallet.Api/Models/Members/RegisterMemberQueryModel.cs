using Domain.Members;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Api.Models.Members
{
    public class RegisterMemberQueryModel
    {
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(4)]
        public string Password { get; set; }

        public Member ToDomain()
        {
            var member = new Member
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
            member.SetPassword(Password);

            return member;
        }
    }
}
