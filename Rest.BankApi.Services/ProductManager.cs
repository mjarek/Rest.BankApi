using Rest.BankApi.Services.Enums;
using Rest.BankApi.Services.Extensions;
using Rest.BankApi.Services.Interfaces;

namespace Rest.BankApi.Services
{
    public class ProductManager : IProductManager
    {
      private IProduct _product;
        public ProductManager(IProduct product)
        {
            _product = product;
        }

        public void CloseProduct()
        {
            if (_product.IsVerified() && _product.IsOpen())
            { 
                _product.Status = StatusProduct.Close;
            }
        }

        public void FreezeProduct()
        {
            if (_product.IsVerified() && _product.IsOpen())
            {
                _product.Status = StatusProduct.Freeze;
            }
        }
    }
}