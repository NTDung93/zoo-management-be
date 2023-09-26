using API.Models.Entities;

namespace API.Models.Dtos
{
    public class AnimalDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string Behavior { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Image { get; set; }

        public byte? HealthStatus { get; set; }

        public string Rarity { get; set; }

        public byte? IsDeleted { get; set; }

        public string EmpId { get; set; } = null;

        public string CageId { get; set; }

        public virtual CageDto Cage { get; set; }

        public virtual EmployeeDto Emp { get; set; }
    }
}
