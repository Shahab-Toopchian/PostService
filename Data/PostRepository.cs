using System.Collections.Generic;
using System.Linq;
using PostService.Models;

namespace PostService.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbcontext;

        public PostRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void CreatePost(Post post)
        {
            _dbcontext.Posts.Add(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _dbcontext.Posts.OrderByDescending(x => x.Id);
        }

        public Post GetPostById(int id)
        {
            return _dbcontext.Posts.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbcontext.SaveChanges() >= 0);
        }
    }
}