namespace SmartPortfolio.Domain.Entities;

public class VisualAsset
{
    public int Id { get; set; }
    public string StudentId { get; set; } = null!;
    public string? VisualType { get; set; } 
    public string? ImageCloudUrl { get; set; }

    public Student Student { get; set; } = null!;
}