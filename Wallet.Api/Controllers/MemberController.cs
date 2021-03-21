using Domain.Accounts;
using Domain.Infrastructure;
using Domain.Members;
using Microsoft.AspNetCore.Mvc;
using Wallet.Api.Models.Members;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMemberAccountService _memberAccountService;

        public MemberController(IMemberService memberService, IMemberAccountService memberAccountService)
        {
            _memberService = memberService;
            _memberAccountService = memberAccountService;
        }

        [HttpGet]
        public IActionResult GetBalance(int memberId)
        {
            var member = _memberService.Get(memberId);
            if (member == null)
            {
                return BadRequest("Member not found");
            }
            var model = MemberViewModel.Create(member);
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Register([FromBody] RegisterMemberQueryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            try
            {
                var member = model.ToDomain();
                var dbMember = _memberService.Add(member);
                dbMember.PasswordHash = "******";
                return Ok(dbMember);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult IncomeMoney([FromBody] MemberAddMoneyQueryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            _memberAccountService.AddOrUpdate(model.ToClaim());
            return Ok();
        }

        [HttpPost]
        public IActionResult WithdrawMoney([FromBody] MemberAddMoneyQueryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            _memberAccountService.WithdrawMoney(model.ToClaim());
            return Ok();
        }
    }
}
