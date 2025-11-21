using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryService.Domain.Entities;

namespace InventoryService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MedicinesController : ControllerBase
{
    private readonly IMedicineService _service;
    public MedicinesController(IMedicineService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var m = await _service.GetByIdAsync(id);
        return m == null ? NotFound() : Ok(m);
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Medicine m) =>
        CreatedAtAction(nameof(GetById), new { id = (await _service.CreateAsync(m)).Id }, m);

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, Medicine m)
    {
        if (id != m.Id) return BadRequest();
        await _service.UpdateAsync(m);
        return NoContent();
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
