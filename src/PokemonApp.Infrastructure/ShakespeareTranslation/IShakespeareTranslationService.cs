using System.Threading.Tasks;

namespace PokemonApp.Infrastructure
{
    public interface IShakespeareTranslationService
    {
        Task<string> Translate(string description);
    }
}