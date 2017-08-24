using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PageantManager.Business.Entities
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
		public int UserId { get; set; }
        public int PerformanceId { get; set; }
        public string Gender { get; set; }
        public int LeaderUserId { get; set; }
        public string Ward { get; set; }
        public string Stake { get; set; }
        public decimal Chest { get; set; }
        public decimal Waist { get; set; }
        public decimal Inseam { get; set; }
        public int? CostumeId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User User { get; set; }
        [ForeignKey("LeaderUserId")]
        public User Leader { get; set; }
        public Performance Performance { get; set; }
	}
}
