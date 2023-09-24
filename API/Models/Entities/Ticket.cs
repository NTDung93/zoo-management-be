namespace API.Models.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string Type { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
