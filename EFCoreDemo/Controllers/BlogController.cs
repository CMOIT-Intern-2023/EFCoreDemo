using EFCoreDemo.Data;
using EFCoreDemo.Models.BlogModels;
using EFCoreDemo.Models.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Controllers
{
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogDBContext _dBContext;
        public BlogController(BlogDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        [HttpGet]
        [Route("/api/Blog/GetAll")]
        public IActionResult GetAllBlogs()
        {
            List<BlogModel>? blogs = _dBContext.Blog.Include(b => b.Posts).ToList();
            List<BlogResponseViewModel> vm = new();

            foreach (var blog in blogs)
            {
                BlogResponseViewModel? response = new BlogResponseViewModel()
                {
                    Id = blog.Id,
                    Url = blog.Url,
                    Content = blog.Content,
                    Posts = new()
                };

                foreach (var post in blog.Posts)
                {
                    response.Posts.Add(new PostResponseViewModel()
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        Content = post.Content
                    });
                }

                vm.Add(response);
            }

            return Ok(vm);
        }

        [HttpPost]
        [Route("/api/Blog/Create")]
        public IActionResult CreateBlog(BlogCreateRequestModel blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            BlogModel blogDto = new()
            {
                Url = blog.Url,
                Content = blog.Content
            };

            foreach (PostCreateRequestModel item in blog.Posts)
            {
                blogDto.Posts.Add(new PostModel()
                {
                    Title = item.Title,
                    Content = item.Content
                });
            }

            _dBContext.Blog.Add(blogDto);
            _dBContext.SaveChanges();

            return Ok();
        }
    }
}
