using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class PostToDtoServiceService : IPostToDtoService
{
    public PostDto PostToDto(Post post)
    {
        return new PostDto()
        {
            Title = post.Title,
            Salary = post.Salary
        };
    }

    public IEnumerable<PostDto> PostToDto(List<Post> posts)
    {
        List<PostDto> postDtos = new();
        
        foreach (var post in posts)
        {
            postDtos.Add(PostToDto(post));
        }

        return postDtos;
    }
}