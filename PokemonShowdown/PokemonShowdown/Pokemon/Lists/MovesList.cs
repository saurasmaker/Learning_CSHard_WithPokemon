using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PokemonShowdown.Pokemon
{
    class MovesList
    {
        #region Attributes
        private static string path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\saves\\moves.xml";

        #endregion


        #region Static Methods
        public static void CreateMovesListXML()
        {
            try
            {
                XDocument doc = PreparedXMLDocument();
                XElement root = new XElement("moves");
                root.Add(AddDataMoveElement(PokeMove.Zero()));
                doc.Add(root);
                doc.Save(path);

                Console.WriteLine("Moves list created succesfully." + root);
            }
            catch (Exception t)
            {
                Console.WriteLine(t.Message);
            }
        }

        public static void SaveMovesListInXML(List<PokeMove> movesList)
        {
            XDocument doc = PreparedXMLDocument();
            XElement root = new XElement("moves");

            foreach (PokeMove m in movesList)
                root.Add(AddDataMoveElement(m));

            doc.Add(root);

            doc.Save(path);

            return;
        }

        public static void SaveMoveInPokedexXML(PokeMove m)
        {
            XDocument doc = GetXMLDocument();

            if (doc == null)
                doc = PreparedXMLDocument();

            doc.Root.Add(AddDataMoveElement(m));
            doc.Save(path);

            return;
        }

        public static List<PokeMove> LoadMovesListFromXML()
        {
            XDocument doc = GetXMLDocument();
            List<PokeMove> moves = null;

            if (doc != null)
            {
                int i = 0;
                foreach (XElement e in doc.Elements("move"))
                {
                    i++;
                    try
                    {
                        PokeMove newMove = LoadDataInMove(e);
                        moves.Add(newMove);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Movement in the position {0} could not be read", i);
                    }
                }
            }

            return moves;
        }



        public static PokeMove LoadMoveFromMovesListXML(string name)
        {
            XDocument doc = GetXMLDocument();
            PokeMove m = null;

            if (doc != null)
                foreach (XElement e in doc.Root.Elements())
                    if (e.Element("name").Value.ToUpper().Equals(name.ToUpper()))
                        m = LoadDataInMove(e);

            return m;
        }

        public static void EditMoveFromMovesListXML(int id, PokeMove p)
        {
            XDocument doc = GetXMLDocument();
            XElement f = null;

            if (doc != null)
                foreach (XElement e in doc.Root.Elements())
                    if (Convert.ToInt32(e.Attribute("id").Value).Equals(id))
                        f = e;

            if (f != null && p != null)
                EditDataInMove(f, p);

            doc.Save(path);

            return;
        }

        public static void RemoveMoveFromMovesListXML(string name)
        {
            XDocument doc = GetXMLDocument();
            XElement p = null;

            if (doc != null)
                foreach (XElement e in doc.Root.Elements())
                    if (e.Element("name").Value.ToUpper().Equals(name.ToUpper()))
                    {
                        p = e;
                        break;
                    }

            p.Remove();

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

        private static XElement AddDataMoveElement(PokeMove m)
        {
            XElement move = new XElement("move");
            move.Add(new XAttribute("id", GenerateId()));
            move.Add(new XElement("name", m.Name));
            move.Add(new XElement("description", m.Description));
            move.Add(new XElement("type", m.Type));
            move.Add(new XElement("category", m.Category));
            move.Add(new XElement("accuarcy", m.Accuarcy));
            move.Add(new XElement("damage", m.Power));
            move.Add(new XElement("recover", m.Recover));
            move.Add(new XElement("repetitions", m.Repetitions));
            move.Add(new XElement("repetitionsInTurn", m.RepetitionsInTurn));
            move.Add(new XElement("target", m.Target));
            move.Add(new XElement("pp", m.PP));
            move.Add(new XElement("contact",m.Contact ? "true" : "false"));
            move.Add(new XElement("priority", m.Priority));

            XElement modifierStats = new XElement("modifierStats");
            modifierStats.Add(new XElement("health", m.ModifierStats[PokeStat.Health]));
            modifierStats.Add(new XElement("attack", m.ModifierStats[PokeStat.Attack]));
            modifierStats.Add(new XElement("specialAttack", m.ModifierStats[PokeStat.SpecialAttack]));
            modifierStats.Add(new XElement("defense", m.ModifierStats[PokeStat.Defense]));
            modifierStats.Add(new XElement("specialDefense", m.ModifierStats[PokeStat.SpecialDefense]));
            modifierStats.Add(new XElement("speed", m.ModifierStats[PokeStat.Speed]));
            modifierStats.Add(new XElement("precision", m.ModifierStats[PokeStat.Precision]));
            modifierStats.Add(new XElement("evasion", m.ModifierStats[PokeStat.Evasion]));
            move.Add(modifierStats);
            move.Add(new XElement("probabilityModifierStats", m.ProbabilityModifierStats));


            XElement modifierEnemyStats = new XElement("modifierStats");
            modifierEnemyStats.Add(new XElement("health", m.ModifierStats[PokeStat.Health]));
            modifierEnemyStats.Add(new XElement("attack", m.ModifierStats[PokeStat.Attack]));
            modifierEnemyStats.Add(new XElement("specialAttack", m.ModifierStats[PokeStat.SpecialAttack]));
            modifierEnemyStats.Add(new XElement("defense", m.ModifierStats[PokeStat.Defense]));
            modifierEnemyStats.Add(new XElement("specialDefense", m.ModifierStats[PokeStat.SpecialDefense]));
            modifierEnemyStats.Add(new XElement("speed", m.ModifierStats[PokeStat.Speed]));
            modifierEnemyStats.Add(new XElement("precision", m.ModifierStats[PokeStat.Precision]));
            modifierEnemyStats.Add(new XElement("evasion", m.ModifierStats[PokeStat.Evasion]));
            move.Add(modifierEnemyStats);
            move.Add(new XElement("probabilityModifierEnemyStats", m.ProbabilityModifierEnemyStats));


            XElement modifierStatus = new XElement("modifierEnemyStatus");
            modifierStatus.Add(new XElement("burn", m.ModifierStatus[PokeStatus.Burn]));
            modifierStatus.Add(new XElement("freeze", m.ModifierStatus[PokeStatus.Freeze]));
            modifierStatus.Add(new XElement("paralysis", m.ModifierStatus[PokeStatus.Paralysis]));
            modifierStatus.Add(new XElement("poison", m.ModifierStatus[PokeStatus.Poison]));
            modifierStatus.Add(new XElement("badlyPoison", m.ModifierStatus[PokeStatus.BadlyPoison]));
            modifierStatus.Add(new XElement("sleep", m.ModifierStatus[PokeStatus.Sleep]));
            move.Add(modifierStatus);
            move.Add(new XElement("probabilityModifierEnemyStatus", m.ProbabilityModifierEnemyStatus));



            XElement modifierEnemyStatus = new XElement("modifierEnemyStatus");
            modifierEnemyStatus.Add(new XElement("burn", m.ModifierEnemyStatus[PokeStatus.Burn]));
            modifierEnemyStatus.Add(new XElement("freeze", m.ModifierEnemyStatus[PokeStatus.Freeze]));
            modifierEnemyStatus.Add(new XElement("paralysis", m.ModifierEnemyStatus[PokeStatus.Paralysis]));
            modifierEnemyStatus.Add(new XElement("poison", m.ModifierEnemyStatus[PokeStatus.Poison]));
            modifierEnemyStatus.Add(new XElement("badlyPoison", m.ModifierEnemyStatus[PokeStatus.BadlyPoison]));
            modifierEnemyStatus.Add(new XElement("sleep", m.ModifierEnemyStatus[PokeStatus.Sleep]));
            move.Add(modifierEnemyStatus);
            move.Add(new XElement("probabilityModifierEnemyStatus", m.ProbabilityModifierEnemyStatus));


            XElement modifierVolatileStatus = new XElement("modifierVolatileStatus");
            modifierVolatileStatus.Add(new XElement("bound", m.ModifierVolatileStatus[VolatilePokeStatus.Bound]));
            modifierVolatileStatus.Add(new XElement("canNotScape", m.ModifierVolatileStatus[VolatilePokeStatus.CanNotScape]));
            modifierVolatileStatus.Add(new XElement("confusion", m.ModifierVolatileStatus[VolatilePokeStatus.Confusion]));
            modifierVolatileStatus.Add(new XElement("curse", m.ModifierVolatileStatus[VolatilePokeStatus.Curse]));
            modifierVolatileStatus.Add(new XElement("embargo", m.ModifierVolatileStatus[VolatilePokeStatus.Embargo]));
            modifierVolatileStatus.Add(new XElement("encore", m.ModifierVolatileStatus[VolatilePokeStatus.Encore]));
            modifierVolatileStatus.Add(new XElement("flinch", m.ModifierVolatileStatus[VolatilePokeStatus.Flinch]));
            modifierVolatileStatus.Add(new XElement("healBlock", m.ModifierVolatileStatus[VolatilePokeStatus.HealBlock]));
            modifierVolatileStatus.Add(new XElement("identified", m.ModifierVolatileStatus[VolatilePokeStatus.Identified]));
            modifierVolatileStatus.Add(new XElement("infatuation", m.ModifierVolatileStatus[VolatilePokeStatus.Infatuation]));
            modifierVolatileStatus.Add(new XElement("leechSeed", m.ModifierVolatileStatus[VolatilePokeStatus.LeechSeed]));
            modifierVolatileStatus.Add(new XElement("nightmare", m.ModifierVolatileStatus[VolatilePokeStatus.Nightmare]));
            modifierVolatileStatus.Add(new XElement("perishSong", m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong]));
            modifierVolatileStatus.Add(new XElement("perishSong", m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong]));
            modifierVolatileStatus.Add(new XElement("telekinesis", m.ModifierVolatileStatus[VolatilePokeStatus.Telekinesis]));
            modifierVolatileStatus.Add(new XElement("torment", m.ModifierVolatileStatus[VolatilePokeStatus.Torment]));
            move.Add(modifierVolatileStatus);
            move.Add(new XElement("probabilityModifierVolatileStatus", m.ProbabilityModifierVolatileStatus));


            XElement modifierEnemyVolatileStatus = new XElement("modifierVolatileStatus");
            modifierEnemyVolatileStatus.Add(new XElement("bound", m.ModifierVolatileStatus[VolatilePokeStatus.Bound]));
            modifierEnemyVolatileStatus.Add(new XElement("canNotScape", m.ModifierVolatileStatus[VolatilePokeStatus.CanNotScape]));
            modifierEnemyVolatileStatus.Add(new XElement("confusion", m.ModifierVolatileStatus[VolatilePokeStatus.Confusion]));
            modifierEnemyVolatileStatus.Add(new XElement("curse", m.ModifierVolatileStatus[VolatilePokeStatus.Curse]));
            modifierEnemyVolatileStatus.Add(new XElement("embargo", m.ModifierVolatileStatus[VolatilePokeStatus.Embargo]));
            modifierEnemyVolatileStatus.Add(new XElement("encore", m.ModifierVolatileStatus[VolatilePokeStatus.Encore]));
            modifierEnemyVolatileStatus.Add(new XElement("flinch", m.ModifierVolatileStatus[VolatilePokeStatus.Flinch]));
            modifierEnemyVolatileStatus.Add(new XElement("healBlock", m.ModifierVolatileStatus[VolatilePokeStatus.HealBlock]));
            modifierEnemyVolatileStatus.Add(new XElement("identified", m.ModifierVolatileStatus[VolatilePokeStatus.Identified]));
            modifierEnemyVolatileStatus.Add(new XElement("infatuation", m.ModifierVolatileStatus[VolatilePokeStatus.Infatuation]));
            modifierEnemyVolatileStatus.Add(new XElement("leechSeed", m.ModifierVolatileStatus[VolatilePokeStatus.LeechSeed]));
            modifierEnemyVolatileStatus.Add(new XElement("nightmare", m.ModifierVolatileStatus[VolatilePokeStatus.Nightmare]));
            modifierEnemyVolatileStatus.Add(new XElement("perishSong", m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong]));
            modifierEnemyVolatileStatus.Add(new XElement("perishSong", m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong]));
            modifierEnemyVolatileStatus.Add(new XElement("telekinesis", m.ModifierVolatileStatus[VolatilePokeStatus.Telekinesis]));
            modifierEnemyVolatileStatus.Add(new XElement("torment", m.ModifierVolatileStatus[VolatilePokeStatus.Torment]));
            move.Add(modifierEnemyVolatileStatus);
            move.Add(new XElement("probabilityModifierEnemyVolatileStatus", m.ProbabilityModifierEnemyVolatileStatus));



            return move;
        }

        private static PokeMove LoadDataInMove(XElement e)
        {            
            PokeMove p = new PokeMove();
            p.Id = Convert.ToInt32(e.Attribute("id").Value);
            p.Name = e.Element("name").Value;
            p.Description = e.Element("description").Value;
            p.Type = Convert.ToByte(e.Element("type").Value);
            p.Category = Convert.ToByte(e.Element("category").Value);
            p.Accuarcy = Convert.ToByte(e.Element("accuarcy").Value);
            p.Power = Convert.ToSByte(e.Element("power").Value);
            p.Recover= Convert.ToSByte(e.Element("recover").Value);
            p.Target = Convert.ToByte(e.Element("target").Value);
            p.PP = Convert.ToByte(e.Element("pp").Value);
            p.Contact  = e.Element("contact").Value.Equals("true") ? true : false;
            p.Priority = Convert.ToByte(e.Element("priority").Value);

            XElement modifierStats = e.Element("modifierStats");
            for (int i = 0; i < modifierStats.Elements().Count(); ++i)
            {
                string s = modifierStats.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierStats[i] = Convert.ToSByte(s);
            }
            p.ProbabilityModifierStats = Convert.ToByte(e.Element("probabilityModifierStats").Value);


            XElement modifierEnemyStats = e.Element("modifierEnemyStats");
            for (int i = 0; i < modifierEnemyStats.Elements().Count(); ++i)
            {
                string s = modifierEnemyStats.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierEnemyStats[i] = Convert.ToSByte(s);
            }
            p.ProbabilityModifierEnemyStats = Convert.ToByte(e.Element("probabilityModifierEnemyStats").Value);

            XElement modifierStatus = e.Element("modifierStatus");
            for (int i = 0; i < modifierStatus.Elements().Count(); ++i)
            {
                string s = modifierStatus.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierStatus[i] = Convert.ToBoolean(Convert.ToByte(s));
            }
            p.ProbabilityModifierStatus = Convert.ToByte(e.Element("probabilityModifierStatus").Value);

            XElement modifierEnemyStatus = e.Element("modifierEnemyStatus");
            for (int i = 0; i < modifierEnemyStatus.Elements().Count(); ++i)
            {
                string s = modifierEnemyStatus.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierEnemyStatus[i] = Convert.ToBoolean(Convert.ToByte(s));
            }
            p.ProbabilityModifierStatus = Convert.ToByte(e.Element("probabilityModifierEnemyStatus").Value);

            XElement modifierVolatileStatus = e.Element("modifierVolatileStatus");
            for (int i = 0; i < modifierVolatileStatus.Elements().Count(); ++i)
            {
                string s = modifierVolatileStatus.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierVolatileStatus[i] = Convert.ToBoolean(Convert.ToByte(s));
            }
            p.ProbabilityModifierVolatileStatus = Convert.ToByte(e.Element("probabilityModifierVolatileStatus").Value);

            XElement modifierEnemyVolatileStatus = e.Element("modifierEnemyVolatileStatus");
            for (int i = 0; i < modifierEnemyVolatileStatus.Elements().Count(); ++i)
            {
                string s = modifierEnemyVolatileStatus.Elements().ElementAt(i).Value;
                if (s != null)
                    p.ModifierEnemyVolatileStatus[i] = Convert.ToBoolean(Convert.ToByte(s));
            }
            p.ProbabilityModifierVolatileStatus = Convert.ToByte(e.Element("probabilityModifierEnemyVolatileStatus").Value);


            return p;
        }

        private static XElement EditDataInMove(XElement move, PokeMove m)
        {
            move.Attribute("id").Value =  m.Id.ToString();
            move.Element("name").Value =  m.Name;
            move.Element("description").Value = m.Description;
            move.Element("type").Value = m.Type.ToString();
            move.Element("category").Value = m.Category.ToString();
            move.Element("accuarcy").Value = m.Accuarcy.ToString();
            move.Element("power").Value = m.Power.ToString();
            move.Element("recover").Value = m.Recover.ToString();
            move.Element("repetitions").Value = m.Repetitions.ToString();
            move.Element("repetitionsInTurn").Value = m.RepetitionsInTurn.ToString();
            move.Element("target").Value = m.Target.ToString();
            move.Element("pp").Value = m.PP.ToString();
            move.Element("contact").Value = m.Contact ? "true" : "false";
            move.Element("priority").Value = m.Priority.ToString();


            XElement modifierStats = move.Element("modifierStats");
            modifierStats.Element("health").Value = m.ModifierStats[PokeStat.Health].ToString();
            modifierStats.Element("attack").Value = m.ModifierStats[PokeStat.Attack].ToString();
            modifierStats.Element("specialAttack").Value = m.ModifierStats[PokeStat.SpecialAttack].ToString();
            modifierStats.Element("defense").Value = m.ModifierStats[PokeStat.Defense].ToString();
            modifierStats.Element("specialDefense").Value = m.ModifierStats[PokeStat.SpecialDefense].ToString();
            modifierStats.Element("speed").Value = m.ModifierStats[PokeStat.Speed].ToString();
            modifierStats.Element("precision").Value = m.ModifierStats[PokeStat.Precision].ToString();
            modifierStats.Element("evasion").Value = m.ModifierStats[PokeStat.Evasion].ToString();

            move.Element("probabilityModifierStats").Value = m.ProbabilityModifierStats.ToString();


            XElement modifierEnemyStats = move.Element("modifierStats");
            modifierEnemyStats.Element("health").Value = m.ModifierStats[PokeStat.Health].ToString();
            modifierEnemyStats.Element("attack").Value = m.ModifierStats[PokeStat.Attack].ToString();
            modifierEnemyStats.Element("specialAttack").Value = m.ModifierStats[PokeStat.SpecialAttack].ToString();
            modifierEnemyStats.Element("defense").Value = m.ModifierStats[PokeStat.Defense].ToString();
            modifierEnemyStats.Element("specialDefense").Value = m.ModifierStats[PokeStat.SpecialDefense].ToString();
            modifierEnemyStats.Element("speed").Value = m.ModifierStats[PokeStat.Speed].ToString();
            modifierEnemyStats.Element("precision").Value = m.ModifierStats[PokeStat.Precision].ToString();
            modifierEnemyStats.Element("evasion").Value = m.ModifierStats[PokeStat.Evasion].ToString();

            move.Element("probabilityModifierEnemyStats").Value  = m.ProbabilityModifierEnemyStats.ToString();


            XElement modifierStatus = move.Element("modifierEnemyStatus");
            modifierStatus.Element("burn").Value = m.ModifierEnemyStatus[PokeStatus.Burn].ToString();
            modifierStatus.Element("freeze").Value = m.ModifierEnemyStatus[PokeStatus.Freeze].ToString();
            modifierStatus.Element("paralysis").Value = m.ModifierEnemyStatus[PokeStatus.Paralysis].ToString();
            modifierStatus.Element("poison").Value = m.ModifierEnemyStatus[PokeStatus.Poison].ToString();
            modifierStatus.Element("badlyPoison").Value = m.ModifierEnemyStatus[PokeStatus.BadlyPoison].ToString();
            modifierStatus.Element("sleep").Value = m.ModifierEnemyStatus[PokeStatus.Sleep].ToString();

            move.Element("probabilityModifierEnemyStatus").Value = m.ProbabilityModifierEnemyStatus.ToString();



            XElement modifierEnemyStatus = move.Element("modifierEnemyStatus");
            modifierEnemyStatus.Element("burn").Value = m.ModifierEnemyStatus[PokeStatus.Burn].ToString();
            modifierEnemyStatus.Element("freeze").Value = m.ModifierEnemyStatus[PokeStatus.Freeze].ToString();
            modifierEnemyStatus.Element("paralysis").Value = m.ModifierEnemyStatus[PokeStatus.Paralysis].ToString();
            modifierEnemyStatus.Element("poison").Value = m.ModifierEnemyStatus[PokeStatus.Poison].ToString();
            modifierEnemyStatus.Element("badlyPoison").Value = m.ModifierEnemyStatus[PokeStatus.BadlyPoison].ToString();
            modifierEnemyStatus.Element("sleep").Value = m.ModifierEnemyStatus[PokeStatus.Sleep].ToString();
            
            move.Element("probabilityModifierEnemyStatus").Value = m.ProbabilityModifierEnemyStatus.ToString();


            XElement modifierVolatileStatus = move.Element("modifierVolatileStatus");
            modifierVolatileStatus.Element("buboundrn").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Bound].ToString();
            modifierVolatileStatus.Element("canNotScape").Value = m.ModifierVolatileStatus[VolatilePokeStatus.CanNotScape].ToString();
            modifierVolatileStatus.Element("confusion").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Confusion].ToString();
            modifierVolatileStatus.Element("curse").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Curse].ToString();
            modifierVolatileStatus.Element("embargo").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Embargo].ToString();
            modifierVolatileStatus.Element("encore").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Encore].ToString();
            modifierVolatileStatus.Element("flinch").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Flinch].ToString();
            modifierVolatileStatus.Element("healBlock").Value = m.ModifierVolatileStatus[VolatilePokeStatus.HealBlock].ToString();
            modifierVolatileStatus.Element("identified").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Identified].ToString();
            modifierVolatileStatus.Element("infatuation").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Infatuation].ToString();
            modifierVolatileStatus.Element("leechSeed").Value = m.ModifierVolatileStatus[VolatilePokeStatus.LeechSeed].ToString();
            modifierVolatileStatus.Element("nightmare").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Nightmare].ToString();
            modifierVolatileStatus.Element("perishSong").Value = m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong].ToString();
            modifierVolatileStatus.Element("perishSong").Value = m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong].ToString();
            modifierVolatileStatus.Element("telekinesis").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Telekinesis].ToString();
            modifierVolatileStatus.Element("torment").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Torment].ToString();
            move.Add(modifierVolatileStatus);
            move.Add(new XElement("probabilityModifierVolatileStatus", m.ProbabilityModifierVolatileStatus));


            XElement modifierEnemyVolatileStatus = move.Element("modifierVolatileStatus");
            modifierEnemyVolatileStatus.Element("buboundrn").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Bound].ToString();
            modifierEnemyVolatileStatus.Element("canNotScape").Value = m.ModifierVolatileStatus[VolatilePokeStatus.CanNotScape].ToString();
            modifierEnemyVolatileStatus.Element("confusion").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Confusion].ToString();
            modifierEnemyVolatileStatus.Element("curse").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Curse].ToString();
            modifierEnemyVolatileStatus.Element("embargo").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Embargo].ToString();
            modifierEnemyVolatileStatus.Element("encore").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Encore].ToString();
            modifierEnemyVolatileStatus.Element("flinch").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Flinch].ToString();
            modifierEnemyVolatileStatus.Element("healBlock").Value = m.ModifierVolatileStatus[VolatilePokeStatus.HealBlock].ToString();
            modifierEnemyVolatileStatus.Element("identified").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Identified].ToString();
            modifierEnemyVolatileStatus.Element("infatuation").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Infatuation].ToString();
            modifierEnemyVolatileStatus.Element("leechSeed").Value = m.ModifierVolatileStatus[VolatilePokeStatus.LeechSeed].ToString();
            modifierEnemyVolatileStatus.Element("nightmare").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Nightmare].ToString();
            modifierEnemyVolatileStatus.Element("perishSong").Value = m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong].ToString();
            modifierEnemyVolatileStatus.Element("perishSong").Value = m.ModifierVolatileStatus[VolatilePokeStatus.PerishSong].ToString();
            modifierEnemyVolatileStatus.Element("telekinesis").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Telekinesis].ToString();
            modifierEnemyVolatileStatus.Element("torment").Value = m.ModifierVolatileStatus[VolatilePokeStatus.Torment].ToString();

            move.Element("probabilityModifierEnemyVolatileStatus").Value = m.ProbabilityModifierEnemyVolatileStatus.ToString();

            return move;
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
