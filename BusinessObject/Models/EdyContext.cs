using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
        => optionsBuilder.UseSqlServer("Server=LAPTOP-Q1ULJ6IS\\SQLEXPRESS;Database=EDY;Uid=sa;Pwd=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achivement>(entity =>
        {
            entity.HasKey(e => e.AchiveId);

            entity.ToTable("Achivement");

            entity.Property(e => e.AchiveId).HasColumnName("AchiveID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory);

            entity.ToTable("Category");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("IDcategory");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
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
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Picture)
                .HasMaxLength(50)
                .HasColumnName("picture");

            entity.HasOne(d => d.Cate).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK_Course_Category");
        });

        modelBuilder.Entity<DetailScore>(entity =>
        {
            entity.ToTable("DetailScore");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.ScoreId).HasColumnName("ScoreID");
            entity.Property(e => e.UserAnsware).HasMaxLength(50);

            entity.HasOne(d => d.Question).WithMany(p => p.DetailScores)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetailScore_Question");

            entity.HasOne(d => d.Score).WithMany(p => p.DetailScores)
                .HasForeignKey(d => d.ScoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetailScore_Score");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Content).HasMaxLength(50);
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Course");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Detail).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(250);

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Course");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotifiId);

            entity.ToTable("Notification");

            entity.Property(e => e.NotifiId).HasColumnName("NotifiID");
            entity.Property(e => e.ContentNotifi).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Money).HasColumnName("money");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_User");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Answare1).HasMaxLength(50);
            entity.Property(e => e.Answare2).HasMaxLength(50);
            entity.Property(e => e.Answare3).HasMaxLength(50);
            entity.Property(e => e.AnswareTrue).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.Question1)
                .HasMaxLength(50)
                .HasColumnName("Question");
            entity.Property(e => e.TestId).HasColumnName("TestID");

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Test");
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

            entity.HasOne(d => d.Test).WithMany(p => p.Scores)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_Test");

            entity.HasOne(d => d.User).WithMany(p => p.Scores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_User");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TesId);

            entity.ToTable("Test");

            entity.Property(e => e.TesId).HasColumnName("TesID");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.TestName).HasMaxLength(50);

            entity.HasOne(d => d.Lesson).WithMany(p => p.Tests)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK_Test_Lesson");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
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

            entity.HasOne(d => d.Achive).WithMany(p => p.UserAchivements)
                .HasForeignKey(d => d.AchiveId)
                .HasConstraintName("FK_User_Achivement_Achivement");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchivements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Achivement_User");
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity.ToTable("User_Course");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollDate).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Course_Course");

            entity.HasOne(d => d.User).WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Course_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
