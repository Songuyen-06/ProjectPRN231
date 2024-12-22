using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Courses = new HashSet<Course>();
        }

        public int SubCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
