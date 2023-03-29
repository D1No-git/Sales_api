using sales_api.Helpers.Articles;
using sales_dll.Models;

namespace sales_api.Interfaces.Sales
{
    public interface ISalesService : IDisposable
    {
        Task<(bool isSuccess, IEnumerable<Purchase>? purchases, string? ErrorMessage)> GetAllPurchases();
        Task<(bool isSucces, Article? article, List<ErrorMessage>? errorMessages)> PostPurchase(Article request);
    }
}
