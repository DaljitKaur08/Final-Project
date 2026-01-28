namespace SpaceExpedition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vault vault = new Vault(10);

            Console.WriteLine("Loading Galactic Vault");
            VaultFileManager.LoadVaultFile("galactic_vault.txt", vault);

            for(int i = 0; i < vault.Count; i++)
            {
                if (vault.Items[i].DecodedName == "")
                {
                    vault.Items[i].DecodedName = Decoder.DecodeArtifactName(vault.Items[i].EncodedName);
                }
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
                if(choice == "1")
                {
                    Console
                }
            }
            
             
                
        }
    }
}
