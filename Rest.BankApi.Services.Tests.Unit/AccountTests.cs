using System;
using FluentAssertions;
using NUnit.Framework;
using Rest.BankApi.Services.Consts;

namespace Rest.BankApi.Services.Tests.Unit
{
    public class AccountTests
    {
        private Account _account;
        private const decimal InitialBalance = 150;
        private const decimal Amount = 49.99m;

        [SetUp]
        public void Setup()
        {
            _account = new Account(Guid.Empty)
            {
                Balance = InitialBalance
            };
        }

        [Test]
        public void WhenAccountIsUnverified_ThenWithdrawalIsImpossible_ThrowException()
        {
            //Arrange
            _account.Status = StatusAccount.Unverified;

            //Act//Assert

            _account.Invoking(y => y.Withdrawal(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsUnverified);
        }

        [Test]
        public void WhenAccountIsVerified_ThenWithdrawalIsPossible_ReturnNewBalance()
        {

            //Arrange
            _account.Status = StatusAccount.Verified;

            //Act
            _account.Withdrawal(Amount);

            //Assert
            _account.Balance.Should().Be(InitialBalance - Amount);
        }

        [Test]
        public void WhenAccountIsVerified_ThenDepositIsPossible_ReturnNewBalance()
        {

            //Arrange
            _account.Status = StatusAccount.Verified;

            //Act
            _account.Deposit(Amount);

            //Assert
            _account.Balance.Should().Be(InitialBalance + Amount);
        }

        [Test]
        public void WhenAccountIsClosed_ThenOperationsAreRejects_ThrowExceptions()
        {

            //Arrange
            _account.Status = StatusAccount.Verified;
            _account.Close();

            //Act//Assert
            _account.Invoking(y => y.Deposit(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsClosed);

            _account.Invoking(y => y.Withdrawal(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsClosed);
        }
    }
}