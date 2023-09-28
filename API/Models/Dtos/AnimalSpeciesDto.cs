using API.Models.Entities;

namespace API.Models.Dtos
{
    public class AnimalSpeciesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CageId { get; set; }
        
        public virtual CageDto Cage { get; set; }

        public virtual ICollection<NewsDto> News { get; set; } = new List<NewsDto>();
    }
}
