namespace SmartPortfolio.Domain.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string? AcademicYear { get; set; }
    public string? CourseName { get; set; }
    public string? Advisor { get; set; }
    public string? PdfUrl { get; set; }

    public ICollection<VisualAsset> VisualAssets { get; set; }

    public Student()
    {
        VisualAssets = new List<VisualAsset>();
    }
}