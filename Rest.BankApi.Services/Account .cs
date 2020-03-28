using System;

namespace Rest.BankApi.Services
{
    public class Account
    {
        public Account(Guid id)
        {
            Id = id;
            Status = StatusAccount.UnVerified;
        }
        public Guid Id { get; }
        public StatusAccount Status { get; set; }
        public decimal Balance { get; set; }
        private bool _isOpen = true;
        private bool _isFreeze;

        public void Withdrawal(decimal amount)
        {
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        private bool IsVerified()
        {
            return Status == StatusAccount.Verified;
        }

        private bool IsOpen()
        {
            return _isOpen;
        }

        private bool IsFreeze()
        {
            return _isFreeze;
        }


    }
}
