using System;
using System.Collections.Generic;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EduCore.Infrastructure
{
    public partial class CoursesDbContext : DbContext
    {
        public CoursesDbContext()
        {
        }

        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminCheckout> AdminCheckouts { get; set; } = null!;
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CompletionStatus> CompletionStatuses { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<StudentCertificate> StudentCertificates { get; set; } = null!;
        public virtual DbSet<StudentCheckout> StudentCheckouts { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CoursesDB; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminCheckout>(entity =>
            {
                entity.HasKey(e => e.CheckoutId)
                    .HasName("PK__AdminChe__E07EF51CEF10BA1C");

                entity.Property(e => e.CheckoutId).HasColumnName("CheckoutID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.InstructorRevenue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlatformFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.AdminCheckoutAdmins)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AdminChec__Admin__14E61A24");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.AdminCheckoutInstructors)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AdminChec__Instr__15DA3E5D");

                entity.HasMany(d => d.Courses)
                    .WithMany(p => p.Checkouts)
                    .UsingEntity<Dictionary<string, object>>(
                        "CheckoutCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CheckoutC__Cours__19AACF41"),
                        r => r.HasOne<AdminCheckout>().WithMany().HasForeignKey("CheckoutId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CheckoutC__Check__18B6AB08"),
                        j =>
                        {
                            j.HasKey("CheckoutId", "CourseId").HasName("PK__Checkout__8CEC2204E3EFCE6B");

                            j.ToTable("CheckoutCourses");

                            j.IndexerProperty<int>("CheckoutId").HasColumnName("CheckoutID");

                            j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                        });
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasIndex(e => e.QuestionId, "IX_Answers_QuestionExcerciseQuestionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Answers_Questions_QuestionExcerciseQuestionId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Certificates_Courses_CourseId");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.LectureId, "IX_Comments_LectureId");

                entity.HasIndex(e => e.ReplyId, "IX_Comments_ReplyId");

                entity.HasIndex(e => e.UserId, "IX_Comments_UserId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.LectureId);

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.InverseReply)
                    .HasForeignKey(d => d.ReplyId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CompletionStatus>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CourseId, e.SectionId, e.LectureId })
                    .HasName("PK_CompletedLectures");

                entity.Property(e => e.CompletedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CompletionStatuses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CompletedLectures_Courses");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.CompletionStatuses)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_CompletedLectures_Lectures");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.CompletionStatuses)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_CompletedLectures_Sections");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompletionStatuses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CompletedLectures_Users");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.InstructorId, "IX_Courses_InstructorID");

                entity.HasIndex(e => e.SubCategoryId, "IX_Courses_SubCategoryId");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK__Courses__Instruc__3F466844");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK__Courses__SubCategor__3E52440B");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_Documents_CourseID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EnrollmentDate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Cours__0E391C95");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Stude__0D44F85C");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasIndex(e => e.LectureId, "IX_Exercises_LectureId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.LectureId);
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasIndex(e => e.SectionId, "IX_Lectures_SectionID");

                entity.Property(e => e.LectureId).HasColumnName("LectureID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VideoURL");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK__Lectures__Sectio__44FF419A");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasIndex(e => e.ExerciseId, "IX_Questions_ExerciseId");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_Reviews_CourseID");

                entity.HasIndex(e => e.StudentId, "IX_Reviews_StudentID");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Rating).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Reviews__CourseI__534D60F1");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Reviews__Student__52593CB8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_Sections_CourseID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Sections__Course__4222D4EF");
            });

            modelBuilder.Entity<StudentCertificate>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CertificateId });

                entity.HasIndex(e => e.CertificateId, "IX_StudentCertificates_CertificateId");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.StudentCertificates)
                    .HasForeignKey(d => d.CertificateId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentCertificates)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StudentCheckout>(entity =>
            {
                entity.HasKey(e => e.CheckoutId)
                    .HasName("PK__Checkout__E07EF51CCFBA1268");

                entity.HasIndex(e => e.CourseId, "IX_Checkouts_CourseID");

                entity.HasIndex(e => e.StudentId, "IX_Checkouts_StudentID");

                entity.Property(e => e.CheckoutId).HasColumnName("CheckoutID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCheckouts)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Checkouts__Cours__571DF1D5");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCheckouts)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Checkouts__Stude__5629CD9C");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CourseId })
                    .HasName("PK__StudentC__7B1A1BB4D2465F24");

                entity.HasIndex(e => e.CourseId, "IX_StudentCourses_CourseID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__Cours__4BAC3F29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCo__UserI__4AB81AF0");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory");

                entity.HasIndex(e => e.CategoryId, "IX_SubCategory_CategoryId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK__SystemSe__54372AFDC5ADF01D");

                entity.HasIndex(e => e.UserId, "IX_SystemSettings_UserID");

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Theme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SystemSettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__SystemSet__UserI__59FA5E80");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_Users_RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Bio).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleID__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
