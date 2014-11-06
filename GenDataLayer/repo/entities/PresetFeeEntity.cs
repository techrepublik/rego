using System;

namespace GenDataLayer.repo.entities
{
    public class PresetFeeEntity
    {
        public int PresetFeeId { get; set; }
        public int? ScheduleFeeId { get; set; }
        public int? SetPresetId { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal? Amount { get; set; }
        public int? FeeParticularId { get; set; }
        public string Particular { get; set; }
        public bool? Active { get; set; }
        public bool? Tuition { get; set; }
        public int? OrderBy { get; set; }
    }
}
