using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PokemonShowdown.Pokemon
{
    class Pokedex
    {
        private static string path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\saves\\pokedex.xml";   
        private List<OPokemon> pokemonList;


        #region Constructors
        public Pokedex()
        {

        }

        public Pokedex(List<OPokemon> pokemonList)
        {
            this.pokemonList = pokemonList;
        }
        #endregion

        #region Static Methods
        public static void CreatePokedexXML()
        {
            try
            {
                XDocument doc = PreparedXMLDocument();
                XElement root = new XElement("pokedex");
                root.Add(AddDataPokemonElement(OPokemon.Zero()));
                doc.Add(root);
                doc.Save(path);
                 
                Console.WriteLine("Pokédex creada correctamente" + root);
            }
            catch (Exception t)
            {
                Console.WriteLine(t.Message);
            }
        }

        public static void SavePokedexInXML(List<OPokemon> pokedex)
        {
            XDocument doc = PreparedXMLDocument();
            XElement root = new XElement("pokedex");

            foreach (OPokemon p in pokedex)
                root.Add(AddDataPokemonElement(p));

            doc.Add(root);

            doc.Save(path);

            return;
        }

        public static void SavePokemonInPokedexXML(OPokemon p)
        {
            XDocument doc = GetXMLDocument();
            
            if (doc == null)
                doc = PreparedXMLDocument();

            doc.Root.Add(AddDataPokemonElement(p));
            doc.Save(path);

            return;
        }

        public static List<OPokemon> LoadPokedexFromXML()
        {
            XDocument doc = GetXMLDocument();
            List<OPokemon> pokemon = null;

            if (doc != null)
            {
                int i = 0;
                foreach (XElement e in doc.Elements("pokemon"))
                {
                    i++;
                    try
                    {
                        OPokemon newPoke = LoadDataInPokemon(e);
                        pokemon.Add(newPoke);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Pokemon in the position {0} could not be read", i);
                    }
                }
            }

            return pokemon;
        }

        

        public static OPokemon LoadPokemonFromPokedexXML(string name)
        {
            XDocument doc = GetXMLDocument();
            OPokemon p = null;

            if (doc != null)
                foreach(XElement e in doc.Root.Elements())
                    if (e.Element("name").Value.ToUpper().Equals(name.ToUpper()))
                        p = LoadDataInPokemon(e);
 
            return p;
        }

        public static void EditPokemonFromPokedexXML(string id, OPokemon p)
        {
            XDocument doc = GetXMLDocument();
            XElement f = null;
            
            if (doc != null)
                foreach (XElement e in doc.Root.Elements())
                    if (e.Attribute("id").Value.ToUpper().Equals(id.ToUpper()))
                        f = e;
            
            if(f!=null && p!=null)
                EditDataInPokemon(f, p);

            doc.Save(path);

            return;
        }


        #region Private Methods
        private static XDocument GetXMLDocument()
        {
            XDocument doc = null;
            try //Check if the XML Document exists
            {
                doc = XDocument.Load(path);
            }
            catch (Exception e)
            { //If not, end Method
                Console.WriteLine(e.Message);
                return null;
            }

            return doc;
        }

        private static XDocument PreparedXMLDocument()
        {
            XDocument doc = new XDocument();

            doc.Add(new XDeclaration("1.0", "utf-8", "yes"));
            doc.Add(new XComment("Pokedex"));
            doc.Add(new XProcessingInstruction("xml-stylesheet", "href = 'MyStyles.css' title = 'Compact' type = 'text/css'"));

            return doc;
        }

        private static XElement AddDataPokemonElement(OPokemon p)
        {
            XElement pokemon = new XElement("pokemon");
            pokemon.Add(new XAttribute("id", GenerateId()));
            pokemon.Add(new XElement("name", p.Name));
            pokemon.Add(new XElement("category", p.Category));
            pokemon.Add(new XElement("description", p.Description));
            pokemon.Add(new XElement("height", p.Height));
            pokemon.Add(new XElement("weight", p.Weight));


            XElement types = new XElement("types");
            types.Add(new XElement("type", p.Types[0]));
            types.Add(new XElement("type", p.Types[1]));
            pokemon.Add(types);

            pokemon.Add(new XElement("health", p.Health));
            pokemon.Add(new XElement("attack", p.Attack));
            pokemon.Add(new XElement("specialAttack", p.SpecialAttack));
            pokemon.Add(new XElement("defense", p.Defense));
            pokemon.Add(new XElement("specialDefense", p.SpecialDefense));
            pokemon.Add(new XElement("speed", p.Speed));

            XElement abilities = new XElement("abilities");
            abilities.Add(new XElement("ability", p.Abilities[0]));
            abilities.Add(new XElement("ability", p.Abilities[1]));
            abilities.Add(new XElement("hidden", p.Abilities[2]));
            pokemon.Add(abilities);

            XElement genres = new XElement("genres");
            genres.Add(new XElement("male", p.Genres[0]));
            genres.Add(new XElement("female", p.Genres[1]));
            pokemon.Add(genres);

            pokemon.Add(new XElement("levelType", p.LevelType));

            pokemon.Add(new XElement("healthEV", p.GivedEVs[0]));
            pokemon.Add(new XElement("attackEV", p.GivedEVs[1]));
            pokemon.Add(new XElement("specialAttackEV", p.GivedEVs[2]));
            pokemon.Add(new XElement("defenseEV", p.GivedEVs[3]));
            pokemon.Add(new XElement("specialDefenseEV", p.GivedEVs[4]));
            pokemon.Add(new XElement("speedEV", p.GivedEVs[5]));

            return pokemon;
        }

        private static OPokemon LoadDataInPokemon(XElement e)
        {

            OPokemon p = new OPokemon();
            p.Id = e.Attribute("id").Value;
            p.Name = e.Element("name").Value;
            p.Category = e.Element("category").Value;
            p.Description = e.Element("description").Value;
            p.Height = Convert.ToUInt16(e.Element("height").Value);
            p.Weight = Convert.ToUInt16(e.Element("weight").Value);

            XElement types = e.Element("types");
            for (int i = 0; i < types.Elements().Count(); ++i)
            {
                string s = types.Elements().ElementAt(i).Value;
                if (s != null)
                    p.Types[i] = Convert.ToByte(s);
            }

            p.Health = Convert.ToByte(e.Element("health").Value);
            p.Attack = Convert.ToByte(e.Element("attack").Value);
            p.SpecialAttack = Convert.ToByte(e.Element("specialAttack").Value);
            p.Defense = Convert.ToByte(e.Element("defense").Value);
            p.SpecialDefense = Convert.ToByte(e.Element("specialDefense").Value);
            p.Speed = Convert.ToByte(e.Element("speed").Value);

            XElement abilities = e.Element("abilities");
            for (int i = 0; i < abilities.Elements().Count(); ++i)
            {
                string s = abilities.Elements().ElementAt(i).Value;

                if (s != null)
                    p.Abilities[i] = Convert.ToByte(s);
            }

            XElement genres = e.Element("genres");
            for (int i = 0; i < genres.Elements().Count(); ++i)
            {
                string s = genres.Elements().ElementAt(i).Value;
                p.Genres[i] = Convert.ToByte(s);
            }

            p.LevelType = Convert.ToByte(e.Element("levelType").Value);

            p.GivedEVs[PokeStat.Health] = Convert.ToByte(e.Element("healthEV").Value);
            p.GivedEVs[PokeStat.Attack] = Convert.ToByte(e.Element("attackEV").Value);
            p.GivedEVs[PokeStat.SpecialAttack] = Convert.ToByte(e.Element("specialAttackEV").Value);
            p.GivedEVs[PokeStat.Defense] = Convert.ToByte(e.Element("defenseEV").Value);
            p.GivedEVs[PokeStat.SpecialDefense] = Convert.ToByte(e.Element("specialDefenseEV").Value);
            p.GivedEVs[PokeStat.Speed] = Convert.ToByte(e.Element("speedEV").Value); 

            return p;
        }

        private static XElement EditDataInPokemon(XElement pokemon, OPokemon p)
        {           
            pokemon.Element("name").Value = p.Name;
            pokemon.Element("category").Value = p.Category;
            pokemon.Element("description").Value = p.Description;
            pokemon.Element("height").Value = p.Height.ToString();
            pokemon.Element("weight").Value = p.Weight.ToString();

            XElement types = pokemon.Element("types");
            for (int i = 0; i < types.Elements().Count(); ++i)
                types.Elements().ElementAt(i).Value = p.Types[i].ToString();

            pokemon.Element("health").Value = p.Health.ToString();
            pokemon.Element("attack").Value = p.Attack.ToString();
            pokemon.Element("defense").Value = p.Defense.ToString();
            pokemon.Element("specialAttack").Value = p.SpecialAttack.ToString();
            pokemon.Element("specialDefense").Value = p.SpecialDefense.ToString();
            pokemon.Element("speed").Value = p.Speed.ToString();

            XElement abilities = pokemon.Element("abilities");
            for (int i = 0; i < abilities.Elements().Count(); ++i)
                abilities.Elements().ElementAt(i).Value = p.Abilities[i].ToString();      
            abilities.Element("hidden").Value = p.Abilities[2].ToString();

            XElement genres = pokemon.Element("genres");
            for (int i = 0; i < genres.Elements().Count(); ++i)
                genres.Elements().ElementAt(i).Value = p.Genres[i].ToString();

            pokemon.Element("levelType").Value = p.LevelType.ToString();

            pokemon.Element("healthEV").Value = p.GivedEVs[PokeStat.Health].ToString();
            pokemon.Element("attackEV").Value = p.GivedEVs[PokeStat.Attack].ToString();
            pokemon.Element("defenseEV").Value = p.GivedEVs[PokeStat.Defense].ToString();
            pokemon.Element("specialAttackEV").Value = p.GivedEVs[PokeStat.SpecialAttack].ToString();
            pokemon.Element("specialDefenseEV").Value = p.GivedEVs[PokeStat.SpecialDefense].ToString();
            pokemon.Element("speedEV").Value = p.GivedEVs[PokeStat.Speed].ToString();

            return pokemon;
        }

        private static int GenerateId()
        {
            XDocument doc = GetXMLDocument();
            IEnumerable<XElement> elements = doc.Root.Elements();

            return (Convert.ToInt32(elements.Last().Attribute("id").Value) + 1);
        }
            #endregion
        
        #endregion


    }
}
