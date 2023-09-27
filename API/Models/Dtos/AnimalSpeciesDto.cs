using API.Models.Entities;

namespace API.Models.Dtos
{
    public class AnimalSpeciesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();
    }
}
