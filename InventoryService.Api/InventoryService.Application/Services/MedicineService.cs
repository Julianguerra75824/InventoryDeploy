using Microsoft.EntityFrameworkCore;
using InventoryService.Infrastructure.Data;
using InventoryService.Domain.Entities;

public class MedicineService : IMedicineService
{
    private readonly InventoryDbContext _context;
    public MedicineService(InventoryDbContext context) => _context = context;

    public async Task<IEnumerable<Medicine>> GetAllAsync() =>
        await _context.Medicines.Where(m => m.Active).ToListAsync();

    public async Task<Medicine?> GetByIdAsync(int id) =>
        await _context.Medicines.FindAsync(id);

    public async Task<Medicine> CreateAsync(Medicine medicine)
    {
        _context.Medicines.Add(medicine);
        await _context.SaveChangesAsync();
        return medicine;
    }

    public async Task UpdateAsync(Medicine medicine)
    {
        _context.Medicines.Update(medicine);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Medicines.FindAsync(id);
        if (entity != null) { entity.Active = false; await _context.SaveChangesAsync(); }
    }
}
