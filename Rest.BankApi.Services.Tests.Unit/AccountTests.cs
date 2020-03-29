using System;
using FluentAssertions;
using NUnit.Framework;
using Rest.BankApi.Services.Consts;

namespace Rest.BankApi.Services.Tests.Unit
{
    public class AccountTests
    {
        private Account _account;
        private IProductManager _productManager;
        private const decimal InitialBalance = 150;
        private const decimal Amount = 49.99m;

        [SetUp]
        public void Setup()
        {
            _account = new Account(Guid.Empty)
            {
                Balance = InitialBalance
            };
            _productManager = new ProductManager(_account);
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
            _productManager.CloseProduct();

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
            _account.Status = StatusProduct.Open;

            ////Act
            _productManager.FreezeProduct();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Freeze);
        }

        [Test]
        public void WhenAccountIsClosed_ThenYCantChangeStatus_ReturnStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusProduct.Close;

            ////Act
            _productManager.FreezeProduct();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Close);
        }

        [Test]
        public void WhenAccountIsOpen_ThenCloseIt_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusProduct.Open;

            ////Act
            _productManager.CloseProduct();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Close);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenCloseIt_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusProduct.Freeze;

            ////Act
            _productManager.CloseProduct();

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Close);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenOpenItUsingDeposit_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusProduct.Freeze;

            ////Act
            _account.Deposit(Amount);

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Open);
            _account.Balance.Should().Be(InitialBalance + Amount);
        }

        [Test]
        public void WhenAccountIsFreeze_ThenOpenItUsingWithdrawal_ReturnNewStatus()
        {
            //Arrange
            _account.StatusOwner = StatusOwner.Verified;
            _account.Status = StatusProduct.Freeze;

            ////Act
            _account.Withdrawal(Amount);

            //Assert
            _account.Status.Should().BeEquivalentTo(StatusProduct.Open);
            _account.Balance.Should().Be(InitialBalance - Amount);
        }
    }
}