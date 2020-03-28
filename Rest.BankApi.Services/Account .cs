using System;
using Rest.BankApi.Services.Consts;

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
                    throw new Exception(Messages.AccountIsUnverified);
                }
            }
            else
            {
                throw new Exception(Messages.AccountIsClosed);
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
                throw new Exception(Messages.AccountIsClosed);
            }
        }

        public void Close()
        {
            if (IsVerified() && IsOpen()) _isOpen = false;
        }

        public void Freeze()
        {
            if (IsVerified() && IsOpen()) _isFreeze = true;
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
