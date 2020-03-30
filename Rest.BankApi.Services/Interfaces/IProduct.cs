using Rest.BankApi.Services.Enums;

namespace Rest.BankApi.Services.Interfaces
{
    public interface IProduct
    {
        StatusProduct Status { get; set; }
        StatusOwner StatusOwner { get; set; }
    }
}