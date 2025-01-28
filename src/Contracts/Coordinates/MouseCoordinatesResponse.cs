namespace MouseTracker.Contracts.Coordinates;

public sealed class MouseCoordinatesResponse
{
    public Guid Id { get; init; }

    public List<CoordinateWithTime> Coordinates { get; init; } = new();
}