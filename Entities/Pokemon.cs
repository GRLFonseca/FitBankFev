using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTCG.Entities
{
     class Pokemon
    {
        public string Name { get; set; }
        public string Numeration { get; set; }
        public string Expation { get; set; }
        public string UrlImage { get; set; }

        public Pokemon(string name, string numeration, string expation, string urlImage)
        {
            Name = name;
            Numeration = numeration;
            Expation = expation;
            UrlImage = urlImage;
        }
        public void JsonGeneration()
        {

        }
    }
}
