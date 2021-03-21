namespace Domain.Members
{
    public interface IMemberService
    {
        Member Add(Member member);
        Member Get(int id);
    }
}
