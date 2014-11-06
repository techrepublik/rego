using System;

namespace GenDataLayer.repo.entities
{
    public class SetPresetFeeEntity
    {
        public int SetPresetFeeId { get; set; }
        public string Note { get; set; }
        public int? SemYrId { get; set; }
        public string SemYrName { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? YearLevelId { get; set; }
        public string YearLevelName { get; set; }
        public string CourseAndYr
        {
            get { return String.Format("{0}, {1}", CourseName, YearLevelName) ; } 
        }
    }
}
