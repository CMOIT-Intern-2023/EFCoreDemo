using System.ComponentModel.DataAnnotations;
using EFCoreDemo.Models.PostModels;

namespace EFCoreDemo.Models.BlogModels
{
    public class BlogModel
    {
        public BlogModel()
        {
            Posts = new();
        }

        public int Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string? Url { get; set; }
        public string? Content { get; set; }

        public List<PostModel> Posts { get; set; }
    }
}
