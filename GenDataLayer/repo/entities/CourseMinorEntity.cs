using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class CourseMinorEntity : CourseMinor
    {
        public string CourseMajorName { get; set; }
        public string MinorName { get; set; }
    }
}
