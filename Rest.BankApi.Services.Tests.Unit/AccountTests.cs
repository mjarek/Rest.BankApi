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
            _account.StatusOwner = StatusOwner.Unverified;

            //Act//Assert

            _account.Invoking(y => y.Withdrawal(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsUnverified);
        }

        [Test]
        public void WhenAccountIsVerified_ThenWithdrawalIsPossible_ReturnNewBalance()
        {

            //Arrange
            _account.StatusOwner = StatusOwner.Verified;

            //Act
            _account.Withdrawal(Amount);

            //Assert
            _account.Balance.Should().Be(InitialBalance - Amount);
        }

        [Test]
        public void WhenAccountIsVerified_ThenDepositIsPossible_ReturnNewBalance()
        {

            //Arrange
            _account.StatusOwner = StatusOwner.Verified;

            //Act
            _account.Deposit(Amount);

            //Assert
            _account.Balance.Should().Be(InitialBalance + Amount);
        }

        [Test]
        public void WhenAccountIsUnverified_ThenDepositIsPossible_ReturnNewBalance()
        {

            //Arrange
            _account.StatusOwner = StatusOwner.Unverified;

            //Act
            _account.Deposit(Amount);

            //Assert
            _account.Balance.Should().Be(InitialBalance + Amount);
        }

        [Test]
        public void WhenAccountIsClosed_ThenOperationsAreRejects_ThrowExceptions()
        {

            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Close();

            //Act//Assert
            _account.Invoking(y => y.Deposit(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsClosed);

            _account.Invoking(y => y.Withdrawal(Amount))
                .Should().Throw<Exception>()
                .WithMessage(Messages.AccountIsClosed);
        }

        [Test]
        public void WhenAccountIsOpen_ThenFreezeIt_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Open;

            ////Act
            _account.Freeze();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Freeze);
        }

        [Test]
        public void WhenAccountIsClosed_ThenYCantChangeStatus_ReturnStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Close;

            ////Act
            _account.Freeze();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Close);
        }

        [Test]
        public void WhenAccountIsOpen_ThenCloseIt_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Open;

            ////Act
            _account.Close();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Close);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenCloseIt_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Freeze;

            ////Act
            _account.Close();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Close);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenOpenItUsingDeposit_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Freeze;

            ////Act
            _account.Deposit(Amount);

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Open);
            _account.Balance.Should().Be(InitialBalance + Amount);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenOpenItUsingWithdrawal_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusAccount.Freeze;

            ////Act
            _account.Withdrawal(Amount);

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusAccount.Open);
            _account.Balance.Should().Be(InitialBalance - Amount);
        }
    }
}