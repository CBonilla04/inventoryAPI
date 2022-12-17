using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers;

[ApiController]
[Route("[controller]")]
public class LotController : Controller
{
    private readonly ILotRepository _lotContext;
    
    public LotController(ILotRepository lotContext){
        _lotContext = lotContext;
    }

    [HttpPost("insertLot")]
    public string insertProduct([FromBody]Lot item){
        return _lotContext.insert(item);
    }

    [HttpGet("getAll")]
    public List<Lot> getAll(){
        return _lotContext.getAll();
    }

    [HttpGet("getById/{idLot}")]
    public Lot getById(int idLot){
        return _lotContext.getById(idLot);
    }

    [HttpDelete("delete/{idLot}")]
    public string delete(int idLot){
        return _lotContext.remove(idLot);
    }

    [HttpPut("update")]
    public string update([FromBody] Lot item){
        return _lotContext.update(item);
    }
}