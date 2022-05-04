using System.Collections.Generic;

namespace News_Test_TaronHarutyunyan.ModelsDto
{
    public class NewsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
