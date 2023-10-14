namespace API.Helpers
{
    public static class AnimalConstraints
    {
        public const string ANIMAL_ID_FORMAT = @"ANI\d{3}";
        
        public const string MALE = "Male";
        public const string FEMALE = "Female";

        public const byte HEALTH_STATUS_OK = 1;
        public const byte HEALTH_STATUS_UNDEFINED = 0;
        public const byte HEALTH_STATUS_BAD = 2;
        
        public const byte ANIMAL_DELETED = 1;
        public const byte ANIMAL_NOT_DELETED = 0;
        
        public const string RARITY_NORMAL = "Normal";
        public const string RARITY_ENDANGERED = "Endangered";
        public const string RARITY_CRITICALLY_ENDANGERED = "Critically Endangered";
        public const string RARITY_VULNERABLE = "Vulnerable";
    }
}
