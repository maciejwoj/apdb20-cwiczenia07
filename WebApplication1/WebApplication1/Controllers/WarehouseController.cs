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
    
    

    
}