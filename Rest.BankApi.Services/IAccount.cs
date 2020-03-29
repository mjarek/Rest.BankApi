namespace Rest.BankApi.Services
{
    public interface IAccount
    {
        void Withdrawal(decimal amount);
        void Deposit(decimal amount);
    }
}