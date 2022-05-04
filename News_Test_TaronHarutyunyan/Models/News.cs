using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace News_Test_TaronHarutyunyan.Models
{
    public class News
    {
        public News()
        {
            Categories = new List<Category>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ICollection<Category> Categories { get; set; }
    }
}
