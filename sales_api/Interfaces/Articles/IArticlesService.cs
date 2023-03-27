using sales_dll.Models;

namespace sales_api.Interfaces.Articles
{
    public interface IArticlesService
    {
        Task<(bool isSuccess, IEnumerable<Article>? articles, string? errorMessage)> GetArticlesAsync();
        Task<(bool isSuccess, Article? article, string? errorMessage)> GetArticleByIdAsync(int id);
        Task<(bool isSuccess, string? errorMessage)> PostArticleAsync(Article request);
    }
}
