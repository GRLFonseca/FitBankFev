using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PokemonTCG.Entities
{
    class Json : PokemonCard
    {
        public void JsonIC()
        {

            var numeracao = Qtepag;
            Directory.CreateDirectory(@"C:\Pokemon\");
            PokemonCard pokemon = new PokemonCard();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string arquivojson = js.Serialize(pokemon);
            StreamWriter SW = new StreamWriter(@"C:\Pokemon\" + pokemon.Name + ".json");
            SW.WriteLine(arquivojson);
            SW.Close();
        }
        public void JsonGeneration(int pag)
        {

            for (int id = 0; id < pag; id++)
            {
                Json json = new Json();
                json.JsonIC();
            }
        }
        public void JsonGenerationArchiveUnique()
        {

            Json json = new Json();
            json.JsonIC();
        }

    }
}
