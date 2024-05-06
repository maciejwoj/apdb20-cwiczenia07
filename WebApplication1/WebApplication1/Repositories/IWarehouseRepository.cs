using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories;

public interface IWarehouseRepository
{
    Task<bool> DoesProductExist(int id);

    Task<ProductDTO> GetProduct(int id);
}