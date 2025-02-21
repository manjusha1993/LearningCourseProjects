using System;
using System.Collections.Generic;

namespace LearningCourseWebAPI.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    //public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
