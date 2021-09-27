using AutoMapper;
using PostService.Dtos;
using PostService.Models;

namespace PostService.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            // source ==> destination
            CreateMap<Post,PostReadDto>();
            CreateMap<CreatePostDto,Post>();

        }
        
    }
}