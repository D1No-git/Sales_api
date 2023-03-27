using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sales_api.Interfaces.Articles;
using sales_dll.Interfaces;
using sales_dll.Models;

namespace sales_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articleService;

        public ArticlesController(IArticlesService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("GetAllArticles")]
        public async Task<IActionResult> GetAllArticles()
        {
            try
            {
                var result = await _articleService.GetArticlesAsync();

                if (result.isSuccess)
                    return Ok(result.articles);

                return NotFound("No articles found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}, inner exception: {ex.InnerException}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            try
            {
                var result = await _articleService.GetArticleByIdAsync(id);

                if (result.isSuccess)
                    return Ok(result.article);

                return NotFound($"No article with Id: {id} found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}, inner exception: {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostArticle(Article request)
        {
            try
            {
                var result = await _articleService.PostArticleAsync(request);

                if (result.isSuccess)
                    return Ok($"Article added.");

                return NotFound("Article not created.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}, inner exception: {ex.InnerException}");
            }
        }
    }
}
