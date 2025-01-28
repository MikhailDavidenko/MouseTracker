using System.Text.Json;
using FluentAssertions;
using Moq;
using MouseTracker.Application.Coordinates;
using MouseTracker.Contracts.Coordinates;
using MouseTracker.Domain.Models;
using MouseTracker.Web.API;

namespace MouseTracker.UnitTests.MouseCoordinates;

public sealed class MouseCoordinatesControllerTests
{
    private readonly MouseCoordinatesController controller;
    private readonly Mock<IMouseCoordinatesService> mockService;

    public MouseCoordinatesControllerTests()
    {
        mockService = new Mock<IMouseCoordinatesService>();
        controller = new MouseCoordinatesController(mockService.Object);
    }

    [Fact]
    public async Task AddMouseCoordinatesAsync_ShouldReturnMouseCoordinatesResponse_WhenCalledWithValidData()
    {
        // Arrange
        var coordinates = new List<CoordinateWithTime>
        {
            new CoordinateWithTime { X = 100, Y = 200, T = DateTime.UtcNow }
        };
        var expectedMouseCoordinate = MouseCoordinate.Create(JsonSerializer.Serialize(coordinates));

        mockService.Setup(service => service.AddAsync(It.IsAny<List<CoordinateWithTime>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedMouseCoordinate);

        // Act
        var result = await controller.AddMouseCoordinatesAsync(coordinates, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedMouseCoordinate.Id);
        result.Coordinates.Should().BeEquivalentTo(coordinates);
    }
    
    [Fact]
    public async Task AddMouseCoordinatesAsync_ShouldThrowArgumentNullException_WhenCoordinatesAreNull()
    {
        // Arrange
        List<CoordinateWithTime> coordinates = null;

        // Act
        Func<Task> act = async () => await controller.AddMouseCoordinatesAsync(coordinates, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }
}