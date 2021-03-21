using Infrastructure.Infrastructure;
using System.Collections.Generic;

namespace Domain.Accounts
{
    public interface IMemberAccountReposotory : IRepository<MemberAccount>
    {
        IEnumerable<MemberAccount> GetByUser(int userId);
        MemberAccount GetByUser(int userId, string currency);
    }
}
