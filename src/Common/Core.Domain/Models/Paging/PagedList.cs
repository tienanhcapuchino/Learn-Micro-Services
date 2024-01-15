using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class PagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Values { get; set; } = new List<T>();
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Values.AddRange(items);
        }
        public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize, int countItem)
        {
            var count = countItem;
            var items = new List<T>();
            if (source.Count() <= pageSize)
            {
                items.AddRange(source);
            }
            else
            {
                items.AddRange(source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
            }
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
