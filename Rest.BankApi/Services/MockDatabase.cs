using System;
using System.Collections.Generic;

namespace Rest.BankApi.Services
{
    public class MockDatabase
    {
        private static readonly Dictionary<Guid, Account> Instances = new Dictionary<Guid, Account>();

        public static Account Get(Guid id)
        {
            if (Instances.ContainsKey(id))
            {
                return Instances[id];
            }

            var instance = new Account(id);
            Instances.Add(id,instance);
            return instance;
        }
    }
}