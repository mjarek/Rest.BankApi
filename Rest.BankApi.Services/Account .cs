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
    }
}
