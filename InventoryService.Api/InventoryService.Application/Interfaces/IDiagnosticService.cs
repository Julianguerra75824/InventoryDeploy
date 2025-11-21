using InventoryService.Domain.Entities;

namespace InventoryService.Application.Interfaces
{
    public interface IDiagnosticService
    {
        Task<IEnumerable<DiagnosticTest>> GetAllAsync();
        Task<DiagnosticTest?> GetByIdAsync(int id);
        Task<DiagnosticTest> CreateAsync(DiagnosticTest d);
        Task UpdateAsync(DiagnosticTest d);
        Task DeleteAsync(int id);
    }
}
