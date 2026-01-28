using System.ComponentModel.Design;
using System.Xml.Serialization;

namespace SpaceExpedition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vault vault = new Vault(10);

            Console.WriteLine("Loading Galactic Vault");
            VaultFileManager.LoadVaultFile("galactic_vault.txt", vault);

            for (int i = 0; i < vault.Count; i++)
            {
                vault.Items[i].DecodedName = Decoder.DecodeArtifactName(vault.Items[i].EncodedName);
            }
            VaultAlgorithms.InsertionSort(vault);
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n Space Expedition Menu");
                Console.WriteLine("1. Add Artifact");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Save and Exit");
                Console.Write("Please Enter Choice :");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Enter artifact file name (without extension):");
                    string fileName = Console.ReadLine();

                    Artifact newArtifact = VaultFileManager.LoadArtifactFile(fileName + ".txt");
                    if (newArtifact == null)
                    {
                        Console.WriteLine("Artifact file not found or invalid");
                    }
                    else
                    {
                        newArtifact.DecodedName = Decoder.DecodeArtifactName(newArtifact.EncodedName);

                        int insertPosition;
                        int found = VaultAlgorithms.BinarySearch(vault, newArtifact.DecodedName, out insertPosition);

                        if (found == -1)
                        {
                            VaultAlgorithms.OrderedInsert(vault, newArtifact, insertPosition);
                            Console.WriteLine("Artifact added");
                        }
                        else
                        {
                            Console.WriteLine("Artifact already exists");
                        }
                    }

                } else if (choice == "2")
                {
                    Console.WriteLine("Vault is empty");
                }
                else
                {
                    Console.WriteLine("\n Inventory");
                    for (int i = 0; i < vault.Count; i++)
                    {
                        Console.WriteLine(vault.Items[i].ToString());
                    }
                }
            }


             else if (choice == "3")
            {
                VaultFileManager.SaveSummary("expedition_summary.txt", vault);
                Console.WriteLine("Saved.Thank you!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please Try Again");
            }

        }

        }
    }
}
