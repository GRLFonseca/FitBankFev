﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonTCG.Entities
{
    class PokemonCard : Pokemon
    {
        public int Qtepag { get; set; }

        public PokemonCard(int qtepag)
        {
            Qtepag = qtepag;
        }

        public PokemonCard(string name, string numeration, string expation, string urlImage) : base(name, numeration, expation, urlImage)
        {

        }
        public object ConvertImage()
        {
            object imagem = null;
            var wc = new WebClient();
            string pag = wc.DownloadString("https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/bw-series/bwp/BW02/");
             var htmldocument = new HtmlAgilityPack.HtmlDocument();
            htmldocument.LoadHtml(pag);
                if (htmldocument != null)
                {
                    imagem = Convert.FromBase64String(UrlImage);
                }


            return imagem;
        }
        public void TackCard()
        {

            var wc = new WebClient();
            string pag = wc.DownloadString("https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/?cardName=&cardText=&evolvesFrom=&simpleSubmit=&format=unlimited&hitPointsMin=0&hitPointsMax=340&retreatCostMin=0&retreatCostMax=5&totalAttackCostMin=0&totalAttackCostMax=5&particularArtist=");
            var htmldocument = new HtmlAgilityPack.HtmlDocument();
            htmldocument.LoadHtml(pag);

            string id = string.Empty;
            string link = string.Empty;
            string id2 = string.Empty;


            foreach (HtmlNode x in htmldocument.GetElementbyId("cardResults").ChildNodes)
            {
                if (x.Attributes.Count > 0)
                {
                    id = x.Attributes["li"].Value;
                    link = "https://www.pokemon.com/" + id;


                }
            }


        }

    }
}
