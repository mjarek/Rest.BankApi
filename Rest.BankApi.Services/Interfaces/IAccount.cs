namespace Rest.BankApi.Services.Interfaces
{
    public interface IAccount
    {
        void Withdrawal(decimal amount);
        void Deposit(decimal amount);
    }
}