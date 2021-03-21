using Domain.Infrastructure;
using System;
using System.Linq;

namespace Domain.Members
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Member Add(Member member)
        {
            if (_unitOfWork.Members.ExistsEmail(member.Email))
            {
                throw new InvalidOperationException("User with this Email already exists.");
            }

            var dbMember = _unitOfWork.Members.Add(member);
            _unitOfWork.Commit();
            return dbMember;
        }

        public Member Get(int id)
        {
            var item = _unitOfWork.Members.GetBy(id);
            if (item == null)
            {
                throw new InvalidOperationException("Member not found.");
            }
            item.Accounts = _unitOfWork.MemberAccounts.GetByUser(id).ToList();
            return item;
        }
    }
}
