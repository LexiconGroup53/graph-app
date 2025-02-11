using API.Models;

namespace API.DTOs;

public class GraphDTO
{
    public int Id { get; set; }
    public List<Line> Lines { get; set; }
}