using API.Models.Entities;

namespace API.Models.Dtos
{
    public class CageDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int? MaxCapacity { get; set; }

        public string AreaId { get; set; }

        public virtual AreaDto Area { get; set; }

    }
}
