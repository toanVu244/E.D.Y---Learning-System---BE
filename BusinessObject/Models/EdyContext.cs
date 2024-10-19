using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models;

public partial class EdyContext : DbContext
{
    public EdyContext()
    {
    }

    public EdyContext(DbContextOptions<EdyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achivement> Achivements { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DetailScore> DetailScores { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchivement> UserAchivements { get; set; }

    public virtual DbSet<UserCourse> UserCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(getConnectionString());

    public string getConnectionString()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        return configuration.GetConnectionString("DB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achivement>(entity =>
        {
            entity.HasKey(e => e.AchiveId);

            entity.ToTable("Achivement");

            entity.Property(e => e.AchiveId).HasColumnName("AchiveID");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory);

            entity.ToTable("Category");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("IDcategory");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CateId).HasColumnName("cateID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Picture)
                .HasMaxLength(500)
                .IsFixedLength()
                .HasColumnName("picture");
        });

        modelBuilder.Entity<DetailScore>(entity =>
        {
            entity.ToTable("DetailScore");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.ScoreId).HasColumnName("ScoreID");
            entity.Property(e => e.UserAnsware)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Content)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Detail)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Picture)
                .HasMaxLength(250)
                .IsFixedLength();
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotifiId);

            entity.ToTable("Notification");

            entity.Property(e => e.NotifiId).HasColumnName("NotifiID");
            entity.Property(e => e.ContentNotifi)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Money).HasColumnName("money");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Answare1)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Answare2)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Answare3)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.AnswareTrue)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.Question1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Question");
            entity.Property(e => e.TestId).HasColumnName("TestID");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.ToTable("Score");

            entity.Property(e => e.ScoreId).HasColumnName("ScoreID");
            entity.Property(e => e.CompleteTime).HasColumnType("date");
            entity.Property(e => e.Score1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Score");
            entity.Property(e => e.TestId).HasColumnName("TestID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TesId);

            entity.ToTable("Test");

            entity.Property(e => e.TesId).HasColumnName("TesID");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.TestName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Vip)
                .HasColumnType("date")
                .HasColumnName("VIP");
        });

        modelBuilder.Entity<UserAchivement>(entity =>
        {
            entity.ToTable("User_Achivement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchiveId).HasColumnName("AchiveID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity.ToTable("User_Course");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollDate).HasColumnType("date");
            entity.Property(e => e.PayMoney).HasColumnName("payMoney");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
