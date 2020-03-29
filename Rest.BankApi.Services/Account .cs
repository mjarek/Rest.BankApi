using System;
using Rest.BankApi.Services.Consts;

namespace Rest.BankApi.Services
{
    public class Account
    {
        public Account(Guid id)
        {
            Id = id;
            Status = StatusAccount.Open;
            StatusOwner = StatusOwner.Unverified;
        }
        public Guid Id { get; }
        public StatusAccount Status { get; set; }
        public StatusOwner StatusOwner { get; set; }
        public decimal Balance { get; set; }

        public void Withdrawal(decimal amount)
        {
            if (IsOpen())
            {
                if (IsVerified())
                {
                    Balance -= amount;
                    if (IsFreeze())
                    {
                        Status = StatusAccount.Open;
                    }
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
                    StatusOwner = StatusOwner.Verified;
                }

                if (IsFreeze())
                {
                    Status = StatusAccount.Open;
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
            if (IsVerified() && IsOpen())
            {
 
                Status = StatusAccount.Close;
            }
        }

        public void Freeze()
        {
            if (IsVerified() && IsOpen())
            {
                Status = StatusAccount.Freeze;
            }
        }

        private bool IsVerified()
        {
            return StatusOwner == StatusOwner.Verified;
        }

        private bool IsOpen()
        {
            return Status != StatusAccount.Close;
        }

        private bool IsFreeze()
        {
            return Status == StatusAccount.Freeze;
        }
    }
}
