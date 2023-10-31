using Microsoft.EntityFrameworkCore.Design;
using System.Runtime.CompilerServices;

namespace API.Models.Entities
{
    public class FoodInventory
    {
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public double InventoryQuantity { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ICollection<ImportHistory> ImportHistories { get; set; }
        public ICollection<FeedingMenu> FeedingSchedules { get; set; }
    }
}
