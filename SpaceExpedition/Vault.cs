using System;
using System.Security.Cryptography.X509Certificates;

namespace SpaceExpedition
{
    internal class Vault
    {
        public Artifact[] Items { get; private set; }
        public int Count { get; private set; }

        public Vault(int startSize)  //Constructor
        {
            Items = new Artifact[startSize];
            Count = 0;
        }
        public void AddAtEnd(Artifact artifact)  // Add artifact at end
        {
            EnsureCapacity();
            Items[Count] = artifact;
            Count++;
        }
        public Artifact GetAt(int index)   // Get artifact safely
        {
            if (index < 0 || index >= Count)
            {
                return null;
            }
            return Items[index];
        }
        private void EnsureCapacity()   // manual resize
        {
            if (Count < Items.Length)
            {
                return;
            }
            Artifact[] bigger = new Artifact[Items.Length * 2];
            for (int i = 0; i < Items.Length; i++)
            {
                bigger[i] = Items[i];
            }
            Items = bigger;
        }
            public void EnsureSpace()
        {
            EnsureCapacity();
        }
        public void IncreaseCount()
        {
            Count++;
        }
        
    }
}
