using InventoryService.Application.Interfaces;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class DiagnosticService : IDiagnosticService
{
    private readonly InventoryDbContext _context;
    public DiagnosticService(InventoryDbContext context) => _context = context;

    public async Task<IEnumerable<DiagnosticTest>> GetAllAsync() =>
        await _context.DiagnosticTests.Where(d => d.Active).ToListAsync();

    public async Task<DiagnosticTest?> GetByIdAsync(int id) => await _context.DiagnosticTests.FindAsync(id);

    public async Task<DiagnosticTest> CreateAsync(DiagnosticTest d)
    {
        _context.DiagnosticTests.Add(d);
        await _context.SaveChangesAsync();
        return d;
    }

    public async Task UpdateAsync(DiagnosticTest d)
    {
        _context.DiagnosticTests.Update(d);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _context.DiagnosticTests.FindAsync(id);
        if (e is not null) { e.Active = false; await _context.SaveChangesAsync(); }
    }
}
