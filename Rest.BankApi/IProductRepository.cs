using System;
using Rest.BankApi.Services;
using Rest.BankApi.Services.Interfaces;

namespace Rest.BankApi
{
    public interface IProductRepository
    {
        Account Get(Guid id);
    }
}