using System;

namespace SpaceExpedition
{
    internal class Artifact : IComparable<Artifact>
    {
        public string EncodedName { get; set; }
        public string DecodedName { get; set; }
        public string Planet { get; set; }
        public string DiscoveryDate { get; set; }
        public string StorageLocation { get; set; }
        public string Description { get; set; }
        public Artifact(string encodedName, string planet, string discoveryDate, string storageLocation, string description)
        {
            EncodedName = encodedName;
            Planet = planet;
            DiscoveryDate = discoveryDate;
            StorageLocation = storageLocation;
            Description = description;
            DecodedName = "";
        }
        public override string ToString()
        {
            return $"{DecodedName} ({EncodedName}) | {Planet} | {DiscoveryDate} | {StorageLocation} | {Description}";
        }
        public int CompareTo(Artifact other)
        {
            if (other == null)
            {
                return -1;
            }
            return string.Compare(DecodedName, other.DecodedName);
        }
    }
    
    
}
