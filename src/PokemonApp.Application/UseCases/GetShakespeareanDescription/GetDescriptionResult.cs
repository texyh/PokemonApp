namespace PokemonApp.Application.UseCases.GetShakespeareanDescription
{
    public abstract class GetDescriptionResult
    {
    }

    public class SuccessResult : GetDescriptionResult
    {
        public SuccessResult(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string  Description { get; set; }
    }

    public class ErrorResult : GetDescriptionResult
    {
        public string Message { get; }

        public ErrorResult(string message)
        {
            Message = message;
        }
    }
}