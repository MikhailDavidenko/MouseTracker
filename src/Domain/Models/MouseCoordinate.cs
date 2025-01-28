namespace MouseTracker.Domain.Models;

/// <summary>
/// Модель координат мыши
/// </summary>
public sealed class MouseCoordinate
{

    private MouseCoordinate(Guid id, string coordinatesJson)
    {
        Id = id;
        CoordinatesJson = coordinatesJson;
    }

    public static MouseCoordinate Create(string coordinatesJson)
    {
        if(string.IsNullOrWhiteSpace(coordinatesJson))
        {
            throw new ArgumentNullException(nameof(coordinatesJson));
        }
        
        return new MouseCoordinate(Guid.NewGuid(), coordinatesJson);
    }
    
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Список координат в json формате
    /// </summary>
    public string CoordinatesJson { get; set; }
}