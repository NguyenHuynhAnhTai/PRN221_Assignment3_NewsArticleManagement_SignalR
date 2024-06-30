using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entities;
using Services.Interfaces;
using System.Text.Json;

namespace NguyenHuynhAnhTaiSignalR.Pages.News
{
    public class NewsDetailModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsDetailModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public NewsArticle NewsArticle { get; set; } = default!;

        public string? Message { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                Message = "Not Found";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }

            var newsarticle = _newsArticleService.GetNewsArticles().FirstOrDefault(m => m.NewsArticleId == id);
            if (newsarticle == null)
            {
                Message = "Not Found";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }
            else
            {
                NewsArticle = newsarticle;
            }
            return Page();
        }
    }
}
