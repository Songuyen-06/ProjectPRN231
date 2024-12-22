using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class User
    {
        public User()
        {
            AdminCheckoutAdmins = new HashSet<AdminCheckout>();
            AdminCheckoutInstructors = new HashSet<AdminCheckout>();
            Comments = new HashSet<Comment>();
            CompletionStatuses = new HashSet<CompletionStatus>();
            Courses = new HashSet<Course>();
            Enrollments = new HashSet<Enrollment>();
            Reviews = new HashSet<Review>();
            StudentCertificates = new HashSet<StudentCertificate>();
            StudentCheckouts = new HashSet<StudentCheckout>();
            StudentCourses = new HashSet<StudentCourse>();
            SystemSettings = new HashSet<SystemSetting>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Password { get; set; } = null!;
        public string? Bio { get; set; }
        public int? RoleId { get; set; }
        public string? UrlImage { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<AdminCheckout> AdminCheckoutAdmins { get; set; }
        public virtual ICollection<AdminCheckout> AdminCheckoutInstructors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CompletionStatus> CompletionStatuses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<StudentCertificate> StudentCertificates { get; set; }
        public virtual ICollection<StudentCheckout> StudentCheckouts { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<SystemSetting> SystemSettings { get; set; }
    }
}
