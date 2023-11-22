using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IPostToDtoService
{
    public PostDto PostToDto(Post post);
    public IEnumerable<PostDto> PostToDto(List<Post> posts);
}