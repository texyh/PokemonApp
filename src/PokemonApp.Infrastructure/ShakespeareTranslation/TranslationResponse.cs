using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Infrastructure.ShakespeareTranslation
{
    public class TranslationResponse
    {
        public Contents  Contents { get; set; }
    }

    public class Contents
    {
       public string Translated { get; set; }
       public string Text { get; set; }
    }
}
