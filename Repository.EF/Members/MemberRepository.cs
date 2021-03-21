using Domain.Members;
using System.Linq;

namespace EFRepository.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly WalletDbContext _walletDbContext;

        public MemberRepository(WalletDbContext walletDbContext)
        {
            _walletDbContext = walletDbContext;
        }

        public Member Add(Member entity)
        {
            var e = _walletDbContext.Members.Add(entity);
            return e.Entity;
        }

        public void Delete(Member entity)
        {
            _walletDbContext.Members.Remove(entity);
        }

        public bool ExistsEmail(string email)
        {
            var emailValue = email.ToLower();
            return _walletDbContext.Members.Any(x => x.Email.ToLower() == emailValue);
        }

        public Member GetBy(int key)
        {
            var item = _walletDbContext.Members.FirstOrDefault(x => x.Id == key);
            return item;
        }

        public void Update(Member entity)
        {
            _walletDbContext.Members.Update(entity);
        }
    }
}
