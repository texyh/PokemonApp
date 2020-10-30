using System;
using MediatR;

namespace PokemonApp.Application.Abstractions.Commands
{
    public interface ICommand : IRequest
    {
        
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        
    }
}