using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Script.Serialization;
using PokemonTCG.Entities;

namespace PokemonTCG
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Pokemon> Pokemon = new List<Pokemon>();
            Console.WriteLine("1 - Acesse o site https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/ ");
            Console.WriteLine("2 - Realize uma pesquisa sem preencher nenhum campo (Clicando em Search)");
            Console.WriteLine("3 - Informe abaixo a quantidade de páginas");
            int qtepag = int.Parse(Console.ReadLine());
            Parallel.For(0, qtepag, i =>
            {
                for (int a = 0; a < qtepag; a++)
                {

                    string name = string.Empty; string numeration = string.Empty; string expation = string.Empty; string urlImage = string.Empty;
                    Pokemon poque = new Pokemon(name, numeration, expation, urlImage);
                    PokemonCard poq = new PokemonCard(qtepag);
                    poq.ConvertImage();
                    poq.TackCard();
                 
                }
            });
            Console.WriteLine("Gravar arquivo em um único json ou em json separado? U/S (U = Único Json / S = Json Separado)");
            char jsonarquivo = char.Parse(Console.ReadLine());
            if (jsonarquivo == 's' || jsonarquivo == 'S')
            {
                Pokemon PokemonJSON = new Pokemon();
                PokemonJSON.JsonGeneration();
            }
            else
            {
                Pokemon PokemonJSON = new Pokemon();
                PokemonJSON.JsonGenerationArchiveUnique();
            }
        }
    }
}

