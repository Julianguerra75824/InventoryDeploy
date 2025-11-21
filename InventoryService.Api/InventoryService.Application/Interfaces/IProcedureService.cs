using InventoryService.Domain.Entities;


namespace InventoryService.Application.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<Procedure>> GetAllAsync();
        Task<Procedure?> GetByIdAsync(int id);
        Task<Procedure> CreateAsync(Procedure p);
        Task UpdateAsync(Procedure p);
        Task DeleteAsync(int id);
    }
}
