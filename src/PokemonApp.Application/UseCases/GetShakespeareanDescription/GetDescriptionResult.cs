using System;

namespace PokemonApp.Application.UseCases.GetShakespeareanDescription
{
    public abstract class GetDescriptionResult
    {
    }

    public class SuccessResult : GetDescriptionResult, IEquatable<SuccessResult>
    {
        public SuccessResult(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string  Description { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SuccessResult);
        }

        public bool Equals(SuccessResult other)
        {
            return other != null &&
                   Name == other.Name &&
                   Description == other.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description);
        }
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