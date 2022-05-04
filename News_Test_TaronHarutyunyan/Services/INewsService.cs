using News_Test_TaronHarutyunyan.Models;
using News_Test_TaronHarutyunyan.ModelsDto;
using System;
using System.Collections.Generic;

namespace News_Test_TaronHarutyunyan.Services
{
    public interface INewsService
    {
        void CreateNews(NewsDto newsDto);
        ICollection<News> GetAllNews();
        ICollection<News> GetNewsByCategory(int id);
        News GetNewsById(int id);
        ICollection<News> GetNewsByDate(DateTime firstDate, DateTime lastDate);
        ICollection<News> GetNewsByText(string searchText);
        void DeleteNews(int id);
        void UpdateNews(NewsDto newsDto,int id);
    }
}
