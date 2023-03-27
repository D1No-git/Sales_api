using sales_api.Helpers.Articles;
using sales_dll.Models;

namespace sales_api.Interfaces.Articles
{
    public interface IArticlesService
    {
        Task<(bool isSuccess, IEnumerable<Article>? articles, string? errorMessage)> GetArticlesAsync();
        Task<(bool isSuccess, Article? article, string? errorMessage)> GetArticleByIdAsync(int id);
        Task<(bool isSuccess, List<ErrorMessage>? errorMessages)> PostArticleAsync(Article request);
        Task<(bool isSuccess, List<ErrorMessage>? errorMessages)> UpdateArticleAsync(Article request);
        Task<(bool isSuccess, string? errorMessage)> DeleteArticleAsync(int id);
    }
}
