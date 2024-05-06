using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseRepository _warehouseRepository;
    public WarehouseController(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        if (!await _warehouseRepository.DoesProductExist(id))
        {
            return NotFound($"Product with given Id - {id} doesn't exist");
        }

        var product = await _warehouseRepository.GetProduct(id);
        return Ok(product);
    }
    
    // [HttpPost]
    // public async Task<IActionResult> AddAnimal(NewAnimalWithProcedures newAnimalWithProcedures)
    // {
    //     if (!await _animalsRepository.DoesOwnerExist(newAnimalWithProcedures.OwnerId))
    //         return NotFound($"Owner with given ID - {newAnimalWithProcedures.OwnerId} doesn't exist");
    //
    //     foreach (var procedure in newAnimalWithProcedures.Procedures)
    //     {
    //         if (!await _animalsRepository.DoesProcedureExist(procedure.ProcedureId))
    //             return NotFound($"Procedure with given ID - {procedure.ProcedureId} doesn't exist");
    //     }
    //
    //     await _animalsRepository.AddNewAnimalWithProcedures(newAnimalWithProcedures);
    //
    //     return Created(Request.Path.Value ?? "api/animals", newAnimalWithProcedures);
    // }
    

    
}