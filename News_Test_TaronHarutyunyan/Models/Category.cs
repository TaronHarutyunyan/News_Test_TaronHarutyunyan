using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace News_Test_TaronHarutyunyan.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonIgnore]       
        public ICollection<News> News { get; set; }
    }
}
