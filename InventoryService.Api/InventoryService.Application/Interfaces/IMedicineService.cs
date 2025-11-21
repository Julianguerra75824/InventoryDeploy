using InventoryService.Domain.Entities;

public interface IMedicineService
{
    Task<IEnumerable<Medicine>> GetAllAsync();
    Task<Medicine?> GetByIdAsync(int id);
    Task<Medicine> CreateAsync(Medicine medicine);
    Task UpdateAsync(Medicine medicine);
    Task DeleteAsync(int id);
}
