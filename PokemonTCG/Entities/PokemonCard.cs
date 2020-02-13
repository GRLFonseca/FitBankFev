using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PokemonTCG.Entities
{
    class PokemonCard : Pokemon
    {
        public int Qtepag { get; set; }
        public string Ash { get; set; }
        public string Atribut { get; set; }
        public string ImagePoke { get; set; }
        public string Linktxt { get; set; }


        public PokemonCard()
        {
        }

        public PokemonCard(int qtepag)
        {
            Qtepag = qtepag;
        }
        public dynamic ConvertImageEncode(dynamic linktxt)
        {
            var web = new WebClient();
            var Text = System.Text.Encoding.UTF8.GetBytes(linktxt);
            return System.Convert.ToBase64String(Text);

        }
        public static string ConvertImageDecode(string linktxt)
        {
            var Text = System.Convert.FromBase64String(linktxt);
            return System.Text.Encoding.UTF8.GetString(Text);
        }
        public void TackCard(int numeracao)
        {
            try
            {
                var wc = new WebClient();
                Dictionary<string, string> image = new Dictionary<string, string>();
                List<string> Links = new List<string>();
                for (int id = 1; id < numeracao; id++)
                {
                    string pag = wc.DownloadString("https://www.pokemon.com/us/pokemon-tcg/pokemon-cards/" + id + "?cardName=&cardText=&evolvesFrom=&simpleSubmit=&format=unlimited&hitPointsMin=0&hitPointsMax=340&retreatCostMin=0&retreatCostMax=5&totalAttackCostMin=0&totalAttackCostMax=5&particularArtist=");
                    HtmlDocument htmldocument = new HtmlDocument();
                    htmldocument.LoadHtml(pag);
                    HtmlNodeCollection linhadominio = htmldocument.DocumentNode.SelectNodes("//ul[@class='cards-grid clear']/li");
                    Parallel.ForEach(linhadominio, dominio =>
                    {
                        var ash = dominio.Element("a");
                        var imagepoke = ash.ChildNodes[1].ChildNodes[1];
                        var atribut = ash.Attributes["href"].Value;
                        var linktxt = imagepoke.Attributes["src"].Value;
                        if (!image.ContainsKey(atribut))
                        {
                            image[atribut] = ConvertImageEncode(linktxt);
                        }


                    });
                }
            }
            catch(HtmlWebException e)
            {
                Console.WriteLine("Um erro ocorreu, verifique! " + e.Message);
            }

        }
    }
}
