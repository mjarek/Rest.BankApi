using System;
using Rest.BankApi.Services;

namespace Rest.BankApi
{
    public class MockDatabase
    {
        private static Account _instance;

        public static Account Get(Guid id)
        {
            return _instance ?? (_instance = new Account(id));
        }

    }
}