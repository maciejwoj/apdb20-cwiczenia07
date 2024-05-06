namespace WebApplication1.Models.DTOs;
using System.ComponentModel.DataAnnotations;

public record ProductToAdd(
    [Required] int IdProduct,
    [Required] int IdWarehouse,
    [Required] int Amount,
    [Required] DateTime CreatedAt
);