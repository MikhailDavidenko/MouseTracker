using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.Coordinates;
using MouseTracker.Contracts.Coordinates;

namespace MouseTracker.Web.API;

[Route("api/v1/[controller]")]
[ApiController]
public sealed class MouseCoordinateController : ControllerBase
{
    private readonly IMouseCoordinatesService mouseCoordinatesService;
    
    public MouseCoordinateController(IMouseCoordinatesService mouseCoordinatesService)
    {
        this.mouseCoordinatesService = mouseCoordinatesService;
    }

    [HttpPost]
    public async Task<MouseCoordinatesResponse> AddMouseCoordinatesAsync(
        [FromBody] List<CoordinateWithTime> coordinate,
        CancellationToken cancellationToken)
    {
        var mouseCoordinate = await mouseCoordinatesService.AddAsync(coordinate, cancellationToken);
        
        var coordinates = JsonSerializer.Deserialize<List<CoordinateWithTime>>(mouseCoordinate.CoordinatesJson);
        
        return new MouseCoordinatesResponse
        {
            Id = mouseCoordinate.Id,
            Coordinates = coordinates
        };
    }
    
}