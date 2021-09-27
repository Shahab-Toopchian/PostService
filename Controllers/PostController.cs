using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostService.Data;
using PostService.Dtos;
using PostService.Models;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;

        public PostController(IPostRepository repo, IMapper mapper )
        {
            _repo=repo;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostReadDto>> GetAllPosts(){
            var posts = _repo.GetAllPosts();
            var postReadItems = _mapper.Map<IEnumerable<PostReadDto>>(posts);
            return Ok(postReadItems);
        }

        [HttpGet("{id}",Name ="GetPostById")]
        public ActionResult<PostReadDto> GetPostById(int id){
            var post = _repo.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }else{
                return Ok(_mapper.Map<PostReadDto>(post));
            }
        }

        [HttpPost]
        public ActionResult<PostReadDto> CreatePost(CreatePostDto createPostDto){
            var post = _mapper.Map<Post>(createPostDto);
            _repo.CreatePost(post);
            _repo.SaveChanges();

            var postReadDto = _mapper.Map<PostReadDto>(post);
            return CreatedAtRoute(nameof(GetPostById),new {id = postReadDto.Id},postReadDto);
        }


    }
}