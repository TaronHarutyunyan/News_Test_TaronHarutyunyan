using Microsoft.EntityFrameworkCore;
using News_Test_TaronHarutyunyan.Models;
using News_Test_TaronHarutyunyan.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News_Test_TaronHarutyunyan.Services
{
    public class NewsService : INewsService
    {
        readonly NewsDbContext _context;
        public NewsService(NewsDbContext context) { _context = context; }
        public void CreateNews(NewsDto newsDto)
        {
            News news = new()
            {
                Description = newsDto.Description,
                Title = newsDto.Title,
                Date = DateTime.Now
            };
            foreach (var id in newsDto.CategoryIds)
            {
                Category _ctg = _context.Categories.FirstOrDefault(x=>x.Id == id);
                if(_ctg != null) news.Categories.Add(_ctg);
            }
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            News news = _context.News.FirstOrDefault(x => x.Id == id);
            if (news == null) throw new KeyNotFoundException();
            _context.Remove(news);
            _context.SaveChanges();
        }

        public ICollection<News> GetAllNews()
        {
            var news= _context.News.Include(o => o.Categories).ToList();
            return news;
        }

        public ICollection<News> GetNewsByCategory(int id)
        {
            ICollection<News> result = new List<News>();
            foreach (var item in _context.News.Include(o=>o.Categories))
            {
                foreach (var category in item.Categories)
                {
                    if (category.Id == id) result.Add(item);
                }
            }
            return result;
        }

        public ICollection<News> GetNewsByDate(DateTime firstDate, DateTime lastDate)
        {
            var result = new List<News>();
            foreach (var item in _context.News)
            {
                if (item.Date >= firstDate && item.Date <= lastDate) result.Add(item);
            }
            return result;
        }

        public News GetNewsById(int id)
        {
            var result = _context.News.FirstOrDefault(x => x.Id == id)??throw new KeyNotFoundException();
            return result;
        }

        public ICollection<News> GetNewsByText(string searchText)
        {
            var result = new List<News>();
            foreach(var item in _context.News)
            {
                if (item.Title.ToLower().Contains(searchText.ToLower()) || item.Description.ToLower().Contains(searchText.ToLower())) result.Add(item);
            }
            return result;
        }

        public void UpdateNews(NewsDto newsDto, int id)
        {
            News news = GetNewsById(id);
            news.Title = newsDto.Title;
            news.Description = newsDto.Description;
            ICollection<Category> categories = new List<Category>();
            foreach (var item in newsDto.CategoryIds)
            {
                Category _ctg = _context.Categories.FirstOrDefault(x => x.Id == item);
                if (_ctg != null) news.Categories.Add(_ctg);
            }
            _context.SaveChanges();
        }
    }
}
