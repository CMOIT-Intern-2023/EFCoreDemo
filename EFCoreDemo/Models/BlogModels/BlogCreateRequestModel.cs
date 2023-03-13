using EFCoreDemo.Models.PostModels;

namespace EFCoreDemo.Models.BlogModels
{
    public class BlogCreateRequestModel
    {
        public BlogCreateRequestModel()
        {
            Posts = new List<PostCreateRequestModel>();
        }

        public string? Url { get; set; }
        public string? Content { get; set; }

        public List<PostCreateRequestModel> Posts { get; set; }
    }
}
