using Infrastructure.Infrastructure;

namespace Domain.Members
{
    public interface IMemberRepository : IRepository<Member>
    {
        bool ExistsEmail(string email);
    }
}
