using Domain.Members;
using System.Collections.Generic;
using System.Linq;

namespace Wallet.Api.Models.Members
{
    public class MemberViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<MemberAccountViewModel> Accounts { get; set; }

        public static MemberViewModel Create(Member member)
        {
            return new MemberViewModel
            {
                Email = member.Email,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Accounts = member.Accounts?.Select(MemberAccountViewModel.Create),
            };
        }
    }
}
