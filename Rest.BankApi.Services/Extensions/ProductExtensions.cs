using Rest.BankApi.Services.Enums;
using Rest.BankApi.Services.Interfaces;

namespace Rest.BankApi.Services.Extensions
{
    public static class ProductExtensions
    {
        public static bool IsVerified(this IProduct product)
        {
            return product.StatusOwner == StatusOwner.Verified;
        }

        public static bool IsOpen(this IProduct product)
        {
            return product.Status != StatusProduct.Close;
        }

        public static bool IsFreeze(this IProduct product)
        {
            return product.Status == StatusProduct.Freeze;
        }
    }
}