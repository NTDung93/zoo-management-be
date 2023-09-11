namespace API.Model.Entities
{
    public class Animal
    {
        public int animalID { get; set; }
        public string animalName { get; set; }
        public string region { get; set; }
        public string description { get; set; }
        public string birthDate { get; set; }
        public string gender { get; set; }
        public bool healthCheck { get; set; }
        public string rarity { get; set; }
    }
}
