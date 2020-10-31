using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Domain.Exceptions
{
    public class PokemonNotFoundException : AppException
    {
        public PokemonNotFoundException(string message, string friendlyMsg) : base(message, friendlyMessage : friendlyMsg)
        {

        }
    }
}
