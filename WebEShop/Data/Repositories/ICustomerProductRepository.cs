using WebEShop.Models;

namespace WebEShop.Data.Repositories
{
    internal interface ICustomerProductRepository
    {
        CustomerProduct Add(CustomerProduct entity, int categoryId);
    }
}