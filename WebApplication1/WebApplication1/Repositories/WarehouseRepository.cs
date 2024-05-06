using System.Data.SqlClient;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly IConfiguration _configuration;

    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> DoesProductExist(int id)
    {
        var query = "SELECT 1 FROM Product WHERE ID = @ID";

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();

        return res is not null;
    }

    public async Task<ProductDTO> GetProduct(int id)
    {
        var query = @"select * from Product where Product.IdProduct = @ID;";

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);

        await connection.OpenAsync();

        var reader = await command.ExecuteReaderAsync();

        var productIdOrdinal = reader.GetOrdinal("Id");
        var productNameOrdinal = reader.GetOrdinal("Name");
        var productDescriptionOrdinal = reader.GetOrdinal("Description");
        var productPriceOrdinal = reader.GetOrdinal("Price");

        ProductDTO productDto = null;

        while (await reader.ReadAsync())
        {
            productDto = new ProductDTO()
            {
                Id = reader.GetInt32(productIdOrdinal),
                Name = reader.GetString(productNameOrdinal),
                Description = reader.GetString(productDescriptionOrdinal),
                Price = reader.GetInt32(productPriceOrdinal)
            };
        }
        if (productDto is null) throw new Exception();
        
        return productDto;

    }
}