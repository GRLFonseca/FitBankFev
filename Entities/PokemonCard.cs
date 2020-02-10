﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PokemonTCG.Entities
{
    class PokemonCard : Pokemon
    {
        public int Qtepag { get; set; }

    
        public PokemonCard(string name, string numeration, string expation, string urlImage, int qtepag) : base(name, numeration,expation,urlImage)
        {
            Qtepag = qtepag;
        }
        public void TackCard()
        {
            var wc = new WebClient();
            string pag = wc.DownloadString("https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/?cardName=&cardText=&evolvesFrom=&simpleSubmit=&format=unlimited&hitPointsMin=0&hitPointsMax=340&retreatCostMin=0&retreatCostMax=5&totalAttackCostMin=0&totalAttackCostMax=5&particularArtist=");
            var htmldocument = new HtmlAgilityPack.HtmlDocument();
            htmldocument.LoadHtml(pag);

            string id = string.Empty;
            string link = string.Empty;

            foreach (HtmlNode x in htmldocument.GetElementbyId("cardResults").ChildNodes)
            {
                if(x.Attributes.Count > 0)
                {
                    id = x.Attributes["a"].Value;
                    link = "https://www.pokemon.com/" + id;
           
                }
            }

         
        }

    }
}
