using MoviesCatalog.Models;

namespace MoviesCatalog.Services.Helpers
{
    public interface ITokenGenerator
    {
        string Generate(User user);
    }
}
