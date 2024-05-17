using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using TurnBasedGame.Classes;

namespace TurnBasedGame.Save_Load
{
    public class SaveAndLoadClass
    {
        private string path;

        public SaveAndLoadClass() {
            path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\Saves");
        }

        public void CreateSaveDirectory()
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("Creating directory failed, error msg:" + e.Message);
            }
            finally { }
        }

        public void SaveCharacter(Character character)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(path,string.Concat( character.Name,".txt"))))
            {
                string[] lines = character.ToSave();
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }

        public Character LoadCharacter(string ChName)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(path, String.Concat(ChName,".txt"))))
            {

            }
            return null;
        }
    }
}
