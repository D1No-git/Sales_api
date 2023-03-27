using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using sales_api.Interfaces.Articles;
using sales_dll.Interfaces;
using sales_dll.Models;
using System.Data;
using System.Data.Common;

namespace sales_api.Services.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly IDapperContext _context;
        private readonly ILogger<ArticlesService> _logger;
        private IDbConnection _db;

        public ArticlesService(IDapperContext context, ILogger<ArticlesService> logger)
        {
            _context = context;
            _logger = logger;
            _db = _context.CreateConnection();
        }

        public async Task<(bool isSuccess, IEnumerable<Article>? articles, string? errorMessage)> GetArticlesAsync()
        {
            try
            {
                string sql = $@"SELECT Id, ArticleNumber, Name, Price, CreatedUTC FROM articles";

                var articles = await _db.QueryAsync<Article>(sql);

                if (!articles.Any())
                    return (false, null, "No articles found.");

                return (true, articles, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, Article? article, string? errorMessage)> GetArticleByIdAsync(int id)
        {
            try
            {
                string sql = $@"SELECT Id, ArticleNumber, Name, Price, CreatedUTC 
                                FROM articles WHERE Id = @Id";

                var result = await _db.QueryAsync<Article>(sql, new { Id = id });

                if (!result.Any())
                    return (false, null, "No article found.");

                return (true, result.FirstOrDefault(), null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string? errorMessage)> PostArticleAsync(Article request)
        {
            try
            {
                if (request == null)
                    return (false, "Request not valid");

                string sql = $@"BEGIN TRANSACTION;
                                INSERT INTO articles (ArticleNumber, Name, Price, CreatedUTC)
                                VALUES (@ArticleNumber, @Name, @Price, @CreatedUTC);
                                COMMIT;";

                var result = await _db.ExecuteAsync(sql, request);

                return (true, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, ex.Message);
            }
        }

        public void Dispose() => _db?.Dispose();
    }
}
