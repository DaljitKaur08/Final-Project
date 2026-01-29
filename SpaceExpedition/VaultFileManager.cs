using System;
using System.IO;

namespace SpaceExpedition
{
    internal class VaultFileManager
    {
        public static void LoadVaultFile(string fileName, Vault vault)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length == 0)
                    {
                        continue;
                    }
                    Artifact artifact = ParseLine(line);
                    if (artifact != null)
                    {
                        vault.AddAtEnd(artifact);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading vault file :" + ex.Message);
            }
        }
        public static Artifact LoadArtifactFile(string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length == 0)
                    {
                        continue;
                    }
                    Artifact artifact = ParseLine(line);
                    reader.Close();
                    return artifact;
                }
                reader.Close();
                Console.WriteLine("No valid artifact found in file");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading artifact file :" + ex.Message);
                return null;
            }
        }
        public static void SaveSummary(string fileName, Vault vault)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);
                for (int i = 0; i < vault.Count; i++)
                {
                    writer.WriteLine(vault.Items[i].ToString());
                }
                writer.Close();
                Console.WriteLine("File saved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving file :" + ex.Message);
            }
        }
        private static Artifact ParseLine(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 5)
            {
                Console.WriteLine("Warning :Bad line skipped");
                return null;
            }
            string encodedName = parts[0].Trim();
            string planet = parts[1].Trim();
            string discoveryDate = parts[2].Trim();
            string storageLocation = parts[3].Trim();

            string description = parts[4].Trim();
            for (int i = 5; i < parts.Length; i++)
            {
                description += " | " + parts[i].Trim();
            }
            return new Artifact(encodedName, planet, discoveryDate, storageLocation, description);
        }
    }
            
        
}
