using System;
using Rest.BankApi.Responses;
using Rest.BankApi.Services.Enums;

namespace Rest.BankApi
{
    public class AccountDetailProvider : IAccountDetailProvider
    {
        private IProductRepository _repository;

        public AccountDetailProvider()
        {
                _repository = new ProductRepository();
        }
        public Result GetStatus(Guid id)
        {
            try
            {
                var result = _repository.Get(id);
                return new Result
                {
                    Balance = result.Balance,
                    Message = string.Empty,
                    StatusProduct = result.Status,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new Result
                {
                    Balance = 0,
                    Message = e.Message,
                    StatusProduct = StatusProduct.Undefined,
                    Success = false
                };
            }
        }
    }
}
