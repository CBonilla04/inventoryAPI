using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    public readonly IProductRepository _context;
    public ProductController(IProductRepository context){
        _context = context;
    }

    [HttpPost("insertProduct")]
    public string insertProduct([FromBody]Product item){
        return _context.insert(item);
    }

    [HttpGet("getAll")]
    public List<Product> getAll(){
        return _context.getAll();
    }

    [HttpGet("getById/{idProduct}")]
    public Product getById(int idProduct){
        return _context.getById(idProduct);
    }

    [HttpDelete("delete/{idProduct}")]
    public string delete(int idProduct){
        return _context.remove(idProduct);
    }

    [HttpPut("update")]
    public string update([FromBody] Product item){
        return _context.update(item);
    }
}