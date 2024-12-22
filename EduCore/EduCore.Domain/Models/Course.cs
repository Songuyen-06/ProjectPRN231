using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Course
    {
        public Course()
        {
            Certificates = new HashSet<Certificate>();
            CompletionStatuses = new HashSet<CompletionStatus>();
            Documents = new HashSet<Document>();
            Enrollments = new HashSet<Enrollment>();
            Reviews = new HashSet<Review>();
            Sections = new HashSet<Section>();
            StudentCheckouts = new HashSet<StudentCheckout>();
            StudentCourses = new HashSet<StudentCourse>();
            Checkouts = new HashSet<AdminCheckout>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public int? InstructorId { get; set; }
        public string? Description { get; set; }
        public string? Level { get; set; }
        public string? Duration { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rating { get; set; }
        public int? SubCategoryId { get; set; }
        public string? Url { get; set; }
        public int Sale { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual User? Instructor { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<CompletionStatus> CompletionStatuses { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<StudentCheckout> StudentCheckouts { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        public virtual ICollection<AdminCheckout> Checkouts { get; set; }
    }
}
