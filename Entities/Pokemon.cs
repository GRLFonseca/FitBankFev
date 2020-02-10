using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace PokemonTCG.Entities
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Numeration { get; set; }
        public string Expation { get; set; }
        public string UrlImage { get; set; }

        public Pokemon()
        {
        }

        public Pokemon(string name, string numeration, string expation, string urlImage)
        {
            Name = name;
            Numeration = numeration;
            Expation = expation;
            UrlImage = urlImage;
        }
        public void JsonGeneration()
        {
            string name = string.Empty;
            string numeration = string.Empty;
            string expation = string.Empty;
            string urlImage = string.Empty;
            Directory.CreateDirectory(@"C:\Pokemon\");
            Pokemon poque = new Pokemon(name, numeration, expation, urlImage);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string arquivojson = js.Serialize(poque);
            StreamWriter SW = new StreamWriter(@"C:\Pokemon\" + Path.GetFileName(Name) + ".json");
            SW.WriteLine(arquivojson);
            SW.Close();
        }
        public void JsonGenerationArchiveUnique()
        {
            string name = string.Empty;
            string numeration = string.Empty;
            string expation = string.Empty;
            string urlImage = string.Empty;
            Directory.CreateDirectory(@"C:\Pokemon\");
            Pokemon poque = new Pokemon(name, numeration, expation, urlImage);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string arquivojson = js.Serialize(poque);
            StreamWriter SW = new StreamWriter(@"C:\Pokemon\PokemonCard.json");
            SW.WriteLine(arquivojson);
            SW.Close();
        }
    }
}
