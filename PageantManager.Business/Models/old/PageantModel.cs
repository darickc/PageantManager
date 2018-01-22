using System.ComponentModel.DataAnnotations;

namespace PageantManager.Business.Models
{
    public class PageantModel
    {
		public int PageantId { get; set; }
		[StringLength(75)]
		public string Name { get; set; }
    }
}
