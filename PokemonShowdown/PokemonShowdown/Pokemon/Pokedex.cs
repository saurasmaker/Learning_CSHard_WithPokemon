using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

namespace PokemonShowdown.Pokemon
{
    class Pokedex
    {
        private static string path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\Saves\\pokedex.xml";   
        private List<OPokemon> pokemonList;


        //Constructors
        public Pokedex()
        {

        }

        public Pokedex(List<OPokemon> pokemonList)
        {
            this.pokemonList = pokemonList;
        }


        //Static Methods
        public static void Create()
        {
            try
            {
                XDocument doc = PreparedXMLDocument();

                //Generating data of XML Document 
                XElement root = new XElement("pokedex");
                XElement pokemon = new XElement("pokemon");
                pokemon.Add(new XAttribute("id", 0));
                pokemon.Add(new XElement("name", "zero"));
                pokemon.Add(new XElement("kind", "zero"));
                pokemon.Add(new XElement("description", "zero"));
                pokemon.Add(new XElement("health", 0));
                pokemon.Add(new XElement("attack", 0));
                pokemon.Add(new XElement("specialAttack", 0));
                pokemon.Add(new XElement("defense", 0));
                pokemon.Add(new XElement("specialDefense", 0));
                pokemon.Add(new XElement("speed", 0));

                root.Add(pokemon);

                doc.Add(root);

                //Saving XML Document
                doc.Save(path);
                 
                Console.WriteLine("Pokédex creada correctamente" + root);
            }
            catch (Exception t)
            {
                Console.WriteLine(t.Message);
            }
        }



        public static void SaveInXML(List<OPokemon> pokedex)
        {
            XDocument doc = PreparedXMLDocument();

            foreach (OPokemon p in pokedex)
            {
                XElement pokemon = new XElement("pokemon");
                pokemon.Add(new XAttribute("id", p.Id));
                pokemon.Add(new XElement("name", p.Name));
                pokemon.Add(new XElement("kind", p.Kind));
                pokemon.Add(new XElement("description", p.Description));
                pokemon.Add(new XElement("health", p.Health));
                pokemon.Add(new XElement("attack", p.Attack));
                pokemon.Add(new XElement("specialAttack", p.SpecialAttack));
                pokemon.Add(new XElement("defense", p.Defense));
                pokemon.Add(new XElement("specialDefense", p.SpecialDefense));
                pokemon.Add(new XElement("speed", p.Speed));

                doc.Root.Add(pokemon);
            }

            doc.Save(path);

            return;
        }



        public static void SavePokemonInXML(OPokemon save)
        {
            XDocument doc = GetXMLDocument();
            if (doc == null)
                doc = PreparedXMLDocument();

            XElement pokemon = new XElement("pokemon");
            pokemon.Add(new XAttribute("id", save.Id));
            pokemon.Add(new XElement("name", save.Name));
            pokemon.Add(new XElement("kind", save.Kind));
            pokemon.Add(new XElement("description", save.Description));
            pokemon.Add(new XElement("health", save.Health));
            pokemon.Add(new XElement("attack", save.Attack));
            pokemon.Add(new XElement("specialAttack", save.SpecialAttack));
            pokemon.Add(new XElement("defense", save.Defense));
            pokemon.Add(new XElement("specialDefense", save.SpecialDefense));
            pokemon.Add(new XElement("speed", save.Speed));

            doc.Root.Add(pokemon);
            doc.Save(path);

            return;
        }



        public static List<OPokemon> LoadFromXML()
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
                        OPokemon newPoke = new OPokemon();
                        newPoke.Id = e.Attribute("id").Value;
                        newPoke.Name = e.Element("name").Value;
                        newPoke.Kind = e.Element("kind").Value;
                        newPoke.Description = e.Element("description").Value;
                        newPoke.Health = Convert.ToByte(e.Element("health").Value);
                        newPoke.Attack = Convert.ToByte(e.Element("attack").Value);
                        newPoke.SpecialAttack = Convert.ToByte(e.Element("specialAttack").Value);
                        newPoke.Defense = Convert.ToByte(e.Element("defense").Value);
                        newPoke.SpecialDefense = Convert.ToByte(e.Element("specialDefense").Value);
                        newPoke.Speed = Convert.ToByte(e.Element("speed").Value);

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

        

        public static OPokemon LoadPokemonFromXML(string name)
        {
            XDocument doc = GetXMLDocument();
            OPokemon pokemon = null;

            if (doc != null)
            {
                foreach(XElement e in doc.Root.Elements())
                {
                    if (e.Element("name").Value.ToUpper().Equals(name.ToUpper()))
                    {
                        pokemon = new OPokemon();
                        pokemon.Id = e.Attribute("id").Value;
                        pokemon.Name = e.Element("name").Value;
                        pokemon.Kind = e.Element("kind").Value;
                        pokemon.Description = e.Element("description").Value;
                        pokemon.Health = Convert.ToByte(e.Element("health").Value);
                        pokemon.Attack = Convert.ToByte(e.Element("attack").Value);
                        pokemon.SpecialAttack = Convert.ToByte(e.Element("specialAttack").Value);
                        pokemon.Defense = Convert.ToByte(e.Element("defense").Value);
                        pokemon.SpecialDefense = Convert.ToByte(e.Element("specialDefense").Value);
                        pokemon.Speed = Convert.ToByte(e.Element("speed").Value);
                    }
                }
            }
            
            return pokemon;
        }

        
        //Private Methods
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

    }
}
