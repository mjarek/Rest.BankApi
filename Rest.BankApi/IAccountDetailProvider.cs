using System;
using Rest.BankApi.Responses;

namespace Rest.BankApi
{
    public interface IAccountDetailProvider
    {
        Result GetStatus(Guid id);
    }
}