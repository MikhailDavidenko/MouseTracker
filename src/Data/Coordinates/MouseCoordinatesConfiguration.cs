using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MouseTracker.Domain.Models;

namespace MouseTracker.Data.Coordinates;

public sealed class MouseCoordinatesConfiguration : IEntityTypeConfiguration<MouseCoordinate>
{
    public void Configure(EntityTypeBuilder<MouseCoordinate> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.CoordinatesJson)
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired();
    }
}