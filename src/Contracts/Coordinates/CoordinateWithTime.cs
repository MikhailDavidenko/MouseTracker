namespace MouseTracker.Contracts.Coordinates;

public sealed class CoordinateWithTime
{
    public DateTime T { get; set; }
    
    public int X { get; set; }
    
    public int Y { get; set; }
}