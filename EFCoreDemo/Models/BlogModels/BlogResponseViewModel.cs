using EFCoreDemo.Models.PostModels;

namespace EFCoreDemo.Models.BlogModels
{
    public class BlogResponseViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public List<PostResponseViewModel> Posts { get; set; }
    }
}
