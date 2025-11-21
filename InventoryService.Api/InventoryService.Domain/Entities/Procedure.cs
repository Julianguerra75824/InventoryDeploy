namespace InventoryService.Domain.Entities;

public class Procedure
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public bool RequiresSpecialist { get; set; }
    public string? SpecialistType { get; set; }
    public bool Active { get; set; } = true;
}
