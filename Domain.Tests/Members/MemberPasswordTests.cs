using Domain.Members;
using NUnit.Framework;

namespace Domain.Tests.Members
{
    public class MemberPasswordTests
    {
        [Test]
        public void ChechMemberPassword()
        {
            var m = new Member();
            m.SetPassword("test");
            var success = m.IsEquealPassword("test");
            var fail = m.IsEquealPassword("test1");

            Assert.IsTrue(success);
            Assert.IsFalse(fail);
        }
    }
}
