using System;
namespace SpaceExpedition
{
    internal class VaultAlgorithms
    {
        public static void InsertionSort(Vault vault)
        {
           for(int i = 1; i < vault.Count; i++)
            {
                Artifact current = vault.Items[i];
                int j;
                for(j = i-1;j >= 0; j--)
                {
                    if (string.Compare(vault.Items[j].DecodedName, current.DecodedName) > 0)
                    {
                        vault.Items[j + 1] = vault.Items[j];
                    }
                    else
                    {
                        break;
                    }
                }
                vault.Items[j + 1] = current;
            }
        }
        public static int BinarySearch(Vault vault , string name , out int insertPosition)
        {
            int start = 0;
            int end = vault.Count - 1;
            insertPosition = 0;

            for(int i = start; i <= end;)
            {
                int middle = (start + end) / 2;
                if (vault.Items[middle].DecodedName == name)
                {
                    insertPosition = middle;
                    return middle;
                }
                if (string.Compare(vault.Items[middle].DecodedName, name) < 0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            insertPosition = start;
            return -1;
        }
        public static void OrderedInsert(Vault vault , Artifact newArtifact, int insertPosition)
        {
            vault.AddAtEnd(newArtifact);
            for (int i = vault.Count - 1; i > insertPosition; i--)
            {
                vault.Items[i] = vault.Items[i - 1];
            }
            vault.Items[insertPosition] = newArtifact;
        }
    }
}
