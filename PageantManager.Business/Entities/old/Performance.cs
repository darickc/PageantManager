//using System;
//using System.ComponentModel.DataAnnotations;
//
//namespace PageantManager.Business.Entities
//{
//    public class Performance
//    {
//        [Key]
//        public int PerformanceId { get; set; }
//        public int PageantId { get; set; }
//
//        public DateTime StartDate { get; set; }
//
//        public DateTime EndDate { get; set; }
//
//        public DateTime ApplicationStartDate { get; set; }
//
//        public DateTime ApplicationEndDate { get; set; }
//
//        [StringLength(150)]
//        public string Description { get; set; }
//
//        public Pageant Pageant { get; set; }
//
//	}
//}
