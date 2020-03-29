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
    }
}