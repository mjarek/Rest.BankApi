namespace Rest.BankApi.Services
{
    public interface IProduct
    {
        StatusProduct Status { get; set; }
        StatusOwner StatusOwner { get; set; }
    }
}