using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearningCourseWebAPI.Models;

public partial class LearningCourseWebApiContext : DbContext
{
    public LearningCourseWebApiContext()
    {
    }

    public LearningCourseWebApiContext(DbContextOptions<LearningCourseWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    //public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LearningCourseWebAPI; Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC075AE3606C");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        //modelBuilder.Entity<Enrollment>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC0707691EED");

        //    entity.Property(e => e.EnrollmentDate)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");

        //    entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
        //        .HasForeignKey(d => d.CourseId)
        //        .HasConstraintName("FK__Enrollmen__Cours__403A8C7D");

        //    entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
        //        .HasForeignKey(d => d.StudentId)
        //        .HasConstraintName("FK__Enrollmen__Stude__3F466844");
        //});

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07963C842B");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D105347F658DEF").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
