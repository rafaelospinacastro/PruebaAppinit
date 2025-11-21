using Microsoft.AspNetCore.Mvc;
using PruebaAppinit.Application.DTOs;
using PruebaAppinit.Application.Services;

namespace Rps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameService _service;
    public GamesController(GameService service) => _service = service;

    [HttpPost("start")]
    public async Task<IActionResult> Start([FromBody] StartGameRequest req, CancellationToken ct)
    {
        var res = await _service.StartGameAsync(req, ct);
        return CreatedAtAction(nameof(Get), new { id = res.GameId }, res);
    }

    [HttpPost("play")]
    public async Task<IActionResult> Play([FromBody] PlayRoundRequest req, CancellationToken ct)
    {
        var res = await _service.PlayRoundAsync(req, ct);
        return Ok(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken ct)
    {
        var res = await _service.GetStatusAsync(id, ct);
        return Ok(res);
    }
}
