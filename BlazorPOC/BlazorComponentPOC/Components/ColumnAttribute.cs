using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Components
{
    public class ColumnAttribute : Attribute
    {
        private string _columnName;
        private int _position;
        private bool _isReadonly;
        public ColumnAttribute(
            string columnName, 
            int position
            )
        {
            _columnName = columnName;
            _position = position;
        }

        public string GetColumnName()
        {
            return _columnName;
        }

        public int GetPosition()
        {
            return _position;
        }

        public string GeIsReadonly()
        {
            return _isReadonly ? "readonly": "";
        }

    }
}
