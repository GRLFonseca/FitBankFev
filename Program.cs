﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using PokemonTCG.Entities;

namespace PokemonTCG
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("1 - Acesse o site https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/ ");
            Console.WriteLine("2 - Realize uma pesquisa sem preencher nenhum campo (Clicando em Search)");
            Console.WriteLine("3 - Informe abaixo a quantidade de páginas");
        }
    }
}