using InventoryService.Application.Interfaces;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ProcedureService : IProcedureService
{
    private readonly InventoryDbContext _context;
    public ProcedureService(InventoryDbContext context) => _context = context;

    public async Task<IEnumerable<Procedure>> GetAllAsync() =>
        await _context.Procedures.Where(p => p.Active).ToListAsync();

    public async Task<Procedure?> GetByIdAsync(int id) => await _context.Procedures.FindAsync(id);

    public async Task<Procedure> CreateAsync(Procedure p)
    {
        _context.Procedures.Add(p);
        await _context.SaveChangesAsync();
        return p;
    }

    public async Task UpdateAsync(Procedure p)
    {
        _context.Procedures.Update(p);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _context.Procedures.FindAsync(id);
        if (e is not null) { e.Active = false; await _context.SaveChangesAsync(); }
    }
}
