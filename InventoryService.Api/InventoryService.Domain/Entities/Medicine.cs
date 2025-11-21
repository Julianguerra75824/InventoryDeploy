namespace InventoryService.Domain.Entities;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DosageForm { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
    public int Stock { get; set; }
    public bool Active { get; set; } = true;
}
