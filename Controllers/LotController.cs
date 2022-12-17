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

    [HttpGet("getAll")]
    public List<Lot> getAll(){
        return _lotContext.getAll();
    }
}