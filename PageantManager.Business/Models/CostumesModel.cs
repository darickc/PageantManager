using System.Collections.Generic;

namespace PageantManager.Business.Models
{
    public class ItemsModel<T>
    {
        public List<T> Items { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public int PageCount { get; set; }
    }
}