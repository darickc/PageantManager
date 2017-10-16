using System.Collections.Generic;

namespace PageantManager.Business.Models
{
    public class ItemsModel<T>
    {
        public ItemsModel(IEnumerable<T> items)
        {
            Items = items;
        }
        public IEnumerable<T> Items { get; set; }
    }
}