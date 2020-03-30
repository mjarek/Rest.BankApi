using System;
using Rest.BankApi.Services.Consts;
using Rest.BankApi.Services.Enums;
using Rest.BankApi.Services.Extensions;
using Rest.BankApi.Services.Interfaces;

namespace Rest.BankApi.Services
{
    public class Account : IProduct, IAccount
    {
        public Account(Guid id)
        {
            Id = id;
            Status = StatusProduct.Open;
            StatusOwner = StatusOwner.Unverified;
        }
        public Guid Id { get; }
        public StatusProduct Status { get; set; }
        public StatusOwner StatusOwner { get; set; }
        public decimal Balance { get; set; }

        public void Withdrawal(decimal amount)
        {
            if (this.IsOpen())
            {
                if (this.IsVerified())
                {
                    Balance -= amount;
                    if (this.IsFreeze())
                    {
                        Status = StatusProduct.Open;
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
            if (this.IsOpen())
            {
                if (!this.IsVerified())
                {
                    StatusOwner = StatusOwner.Verified;
                }

                if (this.IsFreeze())
                {
                    Status = StatusProduct.Open;
                }
                Balance += amount;
            }
            else
            {
                throw new Exception(Messages.AccountIsClosed);
            }
        }
    }
}
