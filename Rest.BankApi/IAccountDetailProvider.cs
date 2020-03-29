﻿using System;
using Rest.BankApi.Responses;

namespace Rest.BankApi
{
    public interface IAccountDetailProvider
    {
        Result GetStatus(Guid id);
        Result Deposit(Guid id, decimal amount);
        Result Withdrawal(Guid id, in decimal amount);
    }
}