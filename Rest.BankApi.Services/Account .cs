using System;

namespace Rest.BankApi.Services
{
    public class Account
    {
        public Account(Guid id)
        {
            Id = id;
            Status = StatusAccount.Unverified;
        }
        public Guid Id { get; }
        public StatusAccount Status { get; set; }
        public decimal Balance { get; set; }
        private bool _isOpen = true;
        private bool _isFreeze;

        public void Withdrawal(decimal amount)
        {
            if (IsOpen())
            {
                if (IsVerified())
                {
                    Balance -= amount;
                    if (IsFreeze()) _isFreeze = false;
                }
                else
                {
                    throw new Exception("Account is unverified");
                }
            }
            else
            {
                throw new Exception("Account is closed");
            }
        }

        public void Deposit(decimal amount)
        {
            if (IsOpen())
            {
                if (!IsVerified())
                {
                    Status = StatusAccount.Verified;
                }

                if (IsFreeze())
                {
                    _isFreeze = false;
                }
                Balance += amount;
            }
            else
            {
                throw new Exception("Account is closed");
            }
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
