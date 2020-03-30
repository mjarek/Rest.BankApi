using System;
using Rest.BankApi.Interfaces;
using Rest.BankApi.Responses;
using Rest.BankApi.Services.Enums;

namespace Rest.BankApi.Services
{
    public class AccountDetailProvider : IAccountDetailProvider
    {
        private readonly IProductRepository _repository;

        public AccountDetailProvider()
        {
            _repository = new ProductRepository();
        }
        public Result GetStatus(Guid id)
        {
            try
            {
                var result = _repository.Get(id);
                return OkResult(result);
            }
            catch (Exception e)
            {
                return ErrorResult(e.Message);
            }
        }

        public Result Deposit(Guid id, decimal amount)
        {
            try
            {
                var result = _repository.IncreaseBalance(id, amount);
                return  OkResult(result);
            }
            catch (Exception e)
            {
                return ErrorResult(e.Message);
            }
        }

        public Result Withdrawal(Guid id, in decimal amount)
        {
            try
            {
                var result = _repository.DecreaseBalance(id, amount);
                return OkResult(result);
            }
            catch (Exception e)
            {
                return ErrorResult(e.Message);
            }
        }

        private Result OkResult(Account account)
        {
            return new Result
            {
                Balance = account.Balance,
                Message = string.Empty,
                StatusProduct = account.Status,
                Success = true
            };
        }

        private Result ErrorResult(string msq)
        {
            return new Result
            {
                Balance = 0,
                Message = msq,
                StatusProduct = StatusProduct.Undefined,
                Success = false
            };
        }
    }
}
