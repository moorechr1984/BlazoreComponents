using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Components
{
    public partial class EditableGridComponent<TRow, TChildRow> : ComponentBase 
                                                                where TRow : class
                                                                where TChildRow : class
    {
        #region Component parameters
        [Parameter]
        public Func<TRow, List<TChildRow>> ChildRowDatasourceCallback { get; set; }

        [Parameter]
        public List<TRow> Datasource { get; set; }

        [Parameter]
        public bool ReadonlyChildGrid { get; set; } = true;

        [Parameter]
        public bool ReadonlyGrid { get; set; } = true;

        [Parameter]
        public bool ShowChildGrid { get; set; }

        [Parameter]
        public bool ShowHideTableIcon { get; set; } = false;
        #endregion

        #region Private class fields
        private string _btnEditGridComponentCancelDisabled { get; set; } = "disabled";
        private string _btnEditGridComponentEditDisabled { get; set; }
        private string _btnEditGridComponentSaveDisabled { get; set; }
        private string _childGridExpandIcon { get; set; } = "oi oi-plus";
        private string _childGridExpandIconStyle { get; set; } = "green";
        private Dictionary<int, bool> _childGridRows = new Dictionary<int, bool>();
        private Dictionary<int, ColumnInfo> _columnNames { get; set; }
        private List<ColumnSort> _columnSortInfo { get; set; }
        private Dictionary<int, object> _columnValues { get; set; }
        private string _gridTheme { get { return _selectedTheme == "Dark" ? "table-dark" : ""; } }
        private bool _hideGrid { get; set; }
        private bool _isLoading { get; set; } = true;
        private List<TRow> _originalDatasource { get; set; }
        private bool _readonlyControl { get; set; }
        private List<TRow> _rowsToBeUsed { get; set; }
        private string _selectedTheme { get; set; }
        private Dictionary<int, Dictionary<int, object>> _transformedRows { get; set; }
        #endregion

        #region Private methods
        private void BuildColumnHeader()
        {
            if (Datasource != null)
            {

                foreach (var row in Datasource)
                {
                    var rowProperties = row.GetType().GetProperties();

                    foreach (var rowProperty in rowProperties)
                    {
                        var columns = rowProperty.GetCustomAttributes(typeof(BlazorComponentPOC.Components.ColumnAttribute), false).OfType<BlazorComponentPOC.Components.ColumnAttribute>();

                        if (_columnNames == null)
                        {
                            _columnNames = new Dictionary<int, ColumnInfo>();
                        }

                        if (!_columnNames.ContainsKey(columns.First().GetPosition()))
                        {
                            _columnNames.Add(columns.First().GetPosition(), new ColumnInfo
                            {
                                ColumnDisplayName = string.IsNullOrWhiteSpace(columns.First().GetColumnName()) ? rowProperty.Name : columns.First().GetColumnName(),
                                ColumnDataPropertyName = rowProperty.Name
                            });
                        }
                    }
                }
            }
        }
        private void BuildRows()
        {
            if (Datasource != null)
            {
                int rowCounter = 1;
                foreach (var row in Datasource)
                {
                    var rowProperties = row.GetType().GetProperties();

                    foreach (var rowProperty in rowProperties)
                    {
                        if (_columnValues == null)
                        {
                            _columnValues = new Dictionary<int, object>();
                        }


                        if (rowProperty.GetCustomAttributes(typeof(BlazorComponentPOC.Components.ColumnAttribute), false).OfType<BlazorComponentPOC.Components.ColumnAttribute>().Any())
                        {
                            var column = rowProperty.GetCustomAttributes(typeof(BlazorComponentPOC.Components.ColumnAttribute), false).OfType<BlazorComponentPOC.Components.ColumnAttribute>().First();
                            if (!_columnValues.ContainsKey(column.GetPosition()))
                            {
                                _columnValues.Add(column.GetPosition(), rowProperty.GetValue(row));
                            }
                        }
                    }
                    if (_transformedRows == null)
                    {
                        _transformedRows = new Dictionary<int, Dictionary<int, object>>();
                    };
                    var copiedColumnValue = _columnValues;
                    if (!_transformedRows.ContainsKey(rowCounter))
                    {
                        _transformedRows.Add(rowCounter, copiedColumnValue);

                        rowCounter++;
                        _columnValues = null;
                    }
                }
            }
        }
        private async Task InitializeComponent()
        {
            if (_originalDatasource == null)
            {
                _originalDatasource = Datasource;
            }
            SetChildGridStyle(false, 0);
            _readonlyControl = true;
            _btnEditGridComponentEditDisabled = null;
            _btnEditGridComponentSaveDisabled = "disabled";
            _isLoading = true;
            StateHasChanged();
            BuildColumnHeader();
            BuildRows();
            _isLoading = false;
            StateHasChanged();
        }
        public void OnClick_btnEditGridComponent_Cancel(MouseEventArgs args)
        {
            _btnEditGridComponentEditDisabled = null;
            _btnEditGridComponentSaveDisabled = "disabled";
            _btnEditGridComponentCancelDisabled = "disabled";
            _readonlyControl = true;
            InitializeComponent();
        }
        private void OnClick_btnEditGridComponent_Edit(MouseEventArgs args)
        {
            _btnEditGridComponentEditDisabled = "disabled";
            _btnEditGridComponentSaveDisabled = null;
            _btnEditGridComponentCancelDisabled = null;
            _readonlyControl = false;
            StateHasChanged();
        }
        private void OnClick_btnEditGridComponent_Save()
        {
            _btnEditGridComponentEditDisabled = null;
            _btnEditGridComponentSaveDisabled = "disabled";
            _btnEditGridComponentCancelDisabled = "disabled";
            _readonlyControl = _readonlyControl;
            StateHasChanged();
        }
        private void OnClick_Header(string columnName)
        {
            _isLoading = true;
            StateHasChanged();

            if (_columnSortInfo == null)
            {
                _columnSortInfo = new List<ColumnSort>();
            }
            int sortOrder = _columnSortInfo.Count();

            if (_columnSortInfo.Any(x => x.ColumnName == columnName))
            {
                var columnInfo = _columnSortInfo.Find(x => x.ColumnName == columnName);
                var copy = columnInfo;
                copy.SortDirection = copy.SortDirection == "ASC" ? "DESC" : "ASC";
                _columnSortInfo.Remove(columnInfo);
                _columnSortInfo.Add(copy);
            }
            else
            {
                _columnSortInfo.Add(new ColumnSort
                {
                    ColumnName = columnName,
                    SortDirection = "DESC",
                    SortOrder = _columnSortInfo.Count + 1
                });
            }

            var type = typeof(TRow);

            var sortProperty = type.GetProperty(_columnSortInfo[0].ColumnName);


            foreach (var sortInfo in _columnSortInfo.OrderBy(x => x.SortOrder))
            {
                if (sortInfo.SortDirection == "ASC")
                {
                    Datasource = Datasource.OrderBy(x => sortProperty.GetValue(x, null)).ToList();
                }
                if (sortInfo.SortDirection == "DESC")
                {
                    Datasource = Datasource.OrderByDescending(x => sortProperty.GetValue(x)).ToList();
                }
            }
            _columnNames = null;
            _transformedRows = null;
            var task = InitializeComponent();
            task.Wait();
        }
        public void OnClick_PlusIcon(int rowNumber, bool showChildGrid)
        {
            SetChildGridStyle(showChildGrid, rowNumber);

            StateHasChanged();
            // InitializeComponent();
        }
        private void OnHideGridClick()
        {
            _hideGrid = true;
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            InitializeComponent();
        }
        private void SetChildGridStyle(bool showChildGrid, int rowNumber)
        {
            if (ShowChildGrid)
            {
                if (!_childGridRows.ContainsKey(rowNumber))
                {
                    _childGridRows.Add(rowNumber, showChildGrid);
                }
                else
                {
                    _childGridRows[rowNumber] = !_childGridRows[rowNumber];
                }


                _childGridExpandIcon = _childGridRows[rowNumber] ? "oi oi-minus" : "oi oi-plus";
                _childGridExpandIconStyle = _childGridRows[rowNumber] ? "red" : "green";
            }
            else
            {
                _childGridExpandIcon = string.Empty;
            }
        }
        #endregion
    }
}
