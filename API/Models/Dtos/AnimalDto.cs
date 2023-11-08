using API.Models.Entities;

namespace API.Models.Dtos
{
    public class AnimalDto
    {
        public string AnimalId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Behavior { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? ImportDate { get; set; }
        public string Image { get; set; }
        public byte? HealthStatus { get; set; }
        public string Rarity { get; set; }
        public byte? IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string EmployeeId { get; set; }
        public string CageId { get; set; }
        public int SpeciesId { get; set; }
        public  EmployeeDto Employee { get; set; }
        public  AnimalSpeciesDto AnimalSpecies { get; set; }
        public  CageDto Cage { get; set; }
    }
}
