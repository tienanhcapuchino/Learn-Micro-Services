using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class TableParameter
    {
        public int Page { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
        public string? SearchContent { get; set; }
        public List<string>? SearchByColumns { get; set; }
        public PageRequestOrderBy? OrderBy { get; set; }
        public IEnumerable<PageRequestFilter>? Filter { get; set; }
        public void AddAdditionalFilters(IEnumerable<PageRequestFilter> additionalFilter)
        {
            var filter = Filter?.ToList();
            if (filter is null)
            {
                filter = new List<PageRequestFilter>();
            }
            filter.AddRange(additionalFilter);
            Filter = filter;
        }
    }

    public class PageRequestOrderBy
    {
        public bool IsAscending { get; set; }
        public string? OrderByKey { get; set; }
    }

    public class PageRequestFilter
    {
        private IEnumerable<string>? _value;
        public string? ColumnName { get; set; }
        public bool IsNullValue { get; set; }
        public IEnumerable<string>? Value
        {
            get { return this.IsNullValue ? new List<string>() : _value; }
            set
            {
                _value = value;
            }
        }
        public bool IncludeNullValue { get; set; } = false;
    }

}
