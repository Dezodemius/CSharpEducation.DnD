using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;
using static System.Net.Mime.MediaTypeNames;

namespace DnD
{
    internal class WordDocument
    {  /// <summary>
    /// Метод для передачи данных в docx файл и конвертации его в PDF
    /// </summary>
        public void CreatePdfSheet(CharacterSheet character, int ProfMax, int SaveStr, int SaveDex, int SaveCons, int SaveIntel, int SaveWisd, int SaveChar)
        {
            if (character == null)
                return;

            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));

            Document document = new Document();
            document.LoadFromFile(Path.Combine(path, "FileTemplate.docx")); //FileTemplate необходимо закинуть в bin...debug
            document.Replace("InputName", character.Name, true, true);
            document.Replace("InputRace", character.Race, true, true);
            document.Replace("InputStr", character.Strenght.ToString(), true, true);
            document.Replace("InputDex", character.Dexterity.ToString(), true, true);
            document.Replace("InputCons", character.Сonstitution.ToString(), true, true);
            document.Replace("InputInt", character.Intelligence.ToString(), true, true);
            document.Replace("InputWis", character.Wisdom.ToString(), true, true);
            document.Replace("InputCharisma", character.Charisma.ToString(), true, true);
            document.Replace("InputHp", character.HitPoints.ToString(), true, true);
            document.Replace("InputArmor", character.ArmorClass.ToString(), true, true);
            document.Replace("InputSpeed", character.Speed.ToString(), true, true);
            if (character.Items.Count == 0)
                document.Replace("InputInv", "Empty", true, true);
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in character.Items)
                {
                    sb.AppendLine(item.GetInfo());
                }
                document.Replace("InputInv", sb.ToString(), true, true);
            }
            document.Replace("acrobatics", character.Acrobatics.ToString(), true, true);
            document.Replace("animalhandl", character.Animal_Handling.ToString(), true, true);
            document.Replace("arcana", character.Arcana.ToString(), true, true);
            document.Replace("atletics", character.Athletics.ToString(), true, true);
            document.Replace("deception", character.Deception.ToString(), true, true);
            document.Replace("history", character.History.ToString(), true, true);
            document.Replace("insight", character.Insight.ToString(), true, true);
            document.Replace("intimidation", character.Intimidation.ToString(), true, true);
            document.Replace("investigation", character.Investigation.ToString(), true, true);
            document.Replace("medicine", character.Medicine.ToString(), true, true);
            document.Replace("nature", character.Nature.ToString(), true, true);
            document.Replace("perception", character.Perception.ToString(), true, true);
            document.Replace("perfomance", character.Performance.ToString(), true, true);
            document.Replace("persuation", character.Persuasion.ToString(), true, true);
            document.Replace("religion", character.Religion.ToString(), true, true);
            document.Replace("sleight", character.Sleight_Of_Hand.ToString(), true, true);
            document.Replace("stealth", character.Stealth.ToString(), true, true);
            document.Replace("survival", character.Survival.ToString(), true, true);

            document.Replace("str", SaveStr.ToString(), true, true);
            document.Replace("dex", SaveDex.ToString(), true, true);
            document.Replace("cons", SaveCons.ToString(), true, true);
            document.Replace("intel", SaveIntel.ToString(), true, true);
            document.Replace("wisd", SaveWisd.ToString(), true, true);
            document.Replace("char", SaveChar.ToString(), true, true);
            document.Replace("profbonus", ProfMax.ToString(), true, true);

            document.SaveToFile($"{character.Name} - {character.Race}.pdf", FileFormat.PDF);
            Console.WriteLine("Файл PDF сохранен");
        }
    }
}
