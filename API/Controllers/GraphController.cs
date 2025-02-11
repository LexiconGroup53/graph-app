using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("graph")]
public class GraphController : Controller
{
    
    [HttpPost]
    public IActionResult SaveGraph(GraphDTO graph)
    {
        
        return Ok(graph.Id);
    }
}