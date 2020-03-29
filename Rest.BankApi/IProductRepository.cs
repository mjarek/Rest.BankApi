using System;
using Rest.BankApi.Services;

namespace Rest.BankApi
{
    public interface IProductRepository
    {
        Account Get(Guid id);
        Account IncreaseBalance(Guid id, decimal amount);
        Account DecreaseBalance(Guid id, decimal amount);
    }
}