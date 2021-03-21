using Domain.Accounts;
using System.Collections.Generic;
using System.Linq;

namespace EFRepository.MemberAccounts
{
    public class MemberAccountRepository : IMemberAccountReposotory
    {
        private readonly WalletDbContext _context;

        public MemberAccountRepository(WalletDbContext context)
        {
            _context = context;
        }

        public MemberAccount Add(MemberAccount entity)
        {
            var e = _context.MemberAccounts.Add(entity);
            return e.Entity;
        }

        public void Delete(MemberAccount entity)
        {
            _context.MemberAccounts.Remove(entity);
        }

        public MemberAccount GetBy(int key)
        {
            return _context.MemberAccounts.FirstOrDefault(x => x.Id == key);
        }

        public IEnumerable<MemberAccount> GetByUser(int userId)
        {
            return _context.MemberAccounts.Where(x => x.UserId == userId).ToArray();
        }

        public MemberAccount GetByUser(int userId, string currency)
        {
            return _context.MemberAccounts.FirstOrDefault(x => x.UserId == userId && x.CurrencyCode == currency);
        }

        public void Update(MemberAccount entity)
        {
            _context.MemberAccounts.Update(entity);
        }
    }
}
