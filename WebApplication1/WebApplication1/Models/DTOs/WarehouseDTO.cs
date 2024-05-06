namespace WebApplication1.Models.DTOs;

public class WarehouseDTO
{
    public int IdWerehouse { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<OrderDTO>  Orders{ get; set; } = null!;
    public List<ProductDTO> Products { get; set; } = null!;
    
}

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    
}

public class OrderDTO
{
    public int IdOrder { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAT { get; set; }
    public DateTime FulfiledAT { get; set; }
    public List<ProductDTO> Products { get; set; } = null!;
}