using System;
using Rest.BankApi.Responses;
using Rest.BankApi.Services;
using Rest.BankApi.Services.Interfaces;

namespace Rest.BankApi
{
    public class ProductRepository : IProductRepository
    {
        public Account Get(Guid id)
        {
            return MockDatabase.Get(id);
        }

        public Account IncreaseBalance(Guid id, decimal amount)
        {
            MockDatabase.Get(id).Deposit(amount);
            return MockDatabase.Get(id);
        }

        public Account DecreaseBalance(Guid id, decimal amount)
        {
            MockDatabase.Get(id).Withdrawal(amount);
            return MockDatabase.Get(id);
        }
    }
}