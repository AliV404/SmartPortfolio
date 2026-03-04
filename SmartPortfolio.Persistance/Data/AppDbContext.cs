using Microsoft.EntityFrameworkCore;
using SmartPortfolio.Domain.Entities;

namespace SmartPortfolio.Persistance.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<VisualAsset> VisualAssets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("student_projects"); 
        
            entity.HasKey(e => e.StudentId);
        
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.AcademicYear).HasColumnName("academic_year");
            entity.Property(e => e.CourseName).HasColumnName("course_name");
            entity.Property(e => e.Advisor).HasColumnName("advisor");
            entity.Property(e => e.PdfUrl).HasColumnName("pdf_url");

            entity.HasMany(e => e.VisualAssets)
                .WithOne(v => v.Student)
                .HasForeignKey(v => v.StudentId);
        });
        
        modelBuilder.Entity<VisualAsset>(entity =>
        {
            entity.ToTable("project_images"); 
        
            entity.HasKey(e => e.Id);
        
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.VisualType).HasColumnName("visual_type");
            entity.Property(e => e.ImageCloudUrl).HasColumnName("image_cloud_url");
        });
    }
}