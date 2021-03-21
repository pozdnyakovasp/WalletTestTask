using Domain.Accounts;
using Domain.Infrastructure;
using Domain.Rates;
using Moq;
using NUnit.Framework;
using System;

namespace Domain.Tests.Converter
{
    public class ConverterTests
    {
        private ICurrencyRateService _target;

        [Test]
        public void CanConvertRubToUse()
        {
            var sourceAccount = new MemberAccount
            {
                Balance = 1000,
            };
            var targetAccount = new MemberAccount
            {
                Balance = 10,
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var memberAccountRepo = new Mock<IMemberAccountReposotory>();
            var rateRepo = new Mock<ICurrencyRateRepoository>();
            rateRepo.Setup(a => a.GetBy(It.IsAny<string>())).Returns<string>((x) =>
            {
                return new CurrencyRate
                {
                    Rate = x == "rub" ? 80 : 0.9m,
                };
            });
            memberAccountRepo.Setup(a => a.GetByUser(It.IsAny<int>(), It.IsAny<string>())).Returns<int, string>((x, y) =>
             {
                 return y == "rub" ? sourceAccount : targetAccount;
             });

            unitOfWork.SetupGet(x => x.MemberAccounts).Returns(memberAccountRepo.Object);
            unitOfWork.SetupGet(x => x.CurrencyRates).Returns(rateRepo.Object);

            _target = new CurrencyConverterService(unitOfWork.Object);
            _target.Convert(new CurrencyConverClaim { From = "rub", To = "Usd", Amount = 100, UserId = 1 });
            var calculeted = _target.CalculateConvert("rub", "use", 100);

            Assert.AreEqual(sourceAccount.Balance, 900);
            Assert.AreEqual(targetAccount.Balance, 11.125);
            Assert.AreEqual(calculeted, 1.125);
        }

        [Test]
        public void CannotConvertRubToUse()
        {
            var sourceAccount = new MemberAccount
            {
                Balance = 10,
            };
            var targetAccount = new MemberAccount
            {
                Balance = 10,
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var memberAccountRepo = new Mock<IMemberAccountReposotory>();
            var rateRepo = new Mock<ICurrencyRateRepoository>();
            rateRepo.Setup(a => a.GetBy(It.IsAny<string>())).Returns<string>((x) =>
            {
                return new CurrencyRate
                {
                    Rate = x == "rub" ? 80 : 0.9m,
                };
            });
            memberAccountRepo.Setup(a => a.GetByUser(It.IsAny<int>(), It.IsAny<string>())).Returns<int, string>((x, y) =>
            {
                return y == "rub" ? sourceAccount : targetAccount;
            });

            unitOfWork.SetupGet(x => x.MemberAccounts).Returns(memberAccountRepo.Object);
            unitOfWork.SetupGet(x => x.CurrencyRates).Returns(rateRepo.Object);

            _target = new CurrencyConverterService(unitOfWork.Object);
            Assert.Catch<InvalidOperationException>(() => _target.Convert(new CurrencyConverClaim { From = "rub", To = "Usd", Amount = 100, UserId = 1 }));
        }
    }
}
