using API.Models.Entities;

namespace API.Models.Dtos
{
    public class CageDto
    {
        public string CageId { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string AreaId { get; set; }
        public AreaDto Area { get; set; }

    }
}
