using EFCoreDemo.Models.BlogModels;

namespace EFCoreDemo.Models.PostModels
{
    public class PostCreateRequestModel
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
