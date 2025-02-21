using System;
using System.Collections.Generic;

namespace LearningCourseWebAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? RegisteredAt { get; set; }

    //public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
