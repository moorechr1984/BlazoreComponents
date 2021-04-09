using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Components
{
    internal class ColumnSort
    {
        public string ColumnName { get; set; }
        public string SortDirection { get; set; }
        public int SortOrder { get; set; }
    }
}
