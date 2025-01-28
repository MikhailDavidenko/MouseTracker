using System.Text.Json;
using FluentAssertions;
using Moq;
using MouseTracker.Application.Coordinates;
using MouseTracker.Contracts.Coordinates;
using MouseTracker.Domain.Models;

namespace MouseTracker.UnitTests.MouseCoordinates;

public sealed class MouseCoordinatesServiceTests
{
    private readonly MouseCoordinatesService service;
    private readonly Mock<IMouseCoordinatesRepository> mockRepository;

    public MouseCoordinatesServiceTests()
    {
        mockRepository = new Mock<IMouseCoordinatesRepository>();
        service = new MouseCoordinatesService(mockRepository.Object);
    }
    
    [Fact]
    public async Task AddAsync_ShouldReturnMouseCoordinate_WhenCalledWithValidData()
    {
        // Arrange
        var coordinates = new List<CoordinateWithTime>
        {
            new CoordinateWithTime { X = 100, Y = 200, T = DateTime.UtcNow }
        };
        
        var expectedMouseCoordinate = MouseCoordinate.Create(JsonSerializer.Serialize(coordinates));
        
        mockRepository.Setup(repo => repo.AddAsync(It.IsAny<MouseCoordinate>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await service.AddAsync(coordinates, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CoordinatesJson.Should().BeEquivalentTo(expectedMouseCoordinate.CoordinatesJson);
    }

    [Fact]
    public async Task AddAsync_ShouldThrowArgumentNullException_WhenCoordinatesAreNull()
    {
        // Arrange
        List<CoordinateWithTime> coordinates = null;

        // Act
        Func<Task> act = async () => await service.AddAsync(coordinates, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }
}