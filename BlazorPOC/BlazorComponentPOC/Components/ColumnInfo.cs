using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Components
{
    internal class ColumnInfo
    {
        public string ColumnDisplayName { get; set; }
        public string ColumnDataPropertyName { get; set; }
        public string SortDirection { get; set; }
        public int SortOrder { get; set; }
    }
}
