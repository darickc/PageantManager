﻿using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class GarmentTypeModel
    {
		public int GarmentTypeId { get; set; }
		public int PageantId { get; set; }
		[StringLength(75)]
		public string Name { get; set; }
    }
}