using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace XHX.Common
{
    public class RowVisibilityHelper : Component
    {
        private GridView _GridView;
        public GridView GridView
        {
            get { return _GridView; }
            set { UnSubscribeEvents(); _GridView = value; SubscribeEvents(); }
        }


        private List<int> _InvisibleRows;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<int> InvisibleRows
        {
            get
            {
                if (_InvisibleRows == null)
                    _InvisibleRows = new List<int>();
                return _InvisibleRows;
            }
            set { _InvisibleRows = value; }
        }

        private void UnSubscribeEvents()
        {
            if (GridView != null)
                GridView.CustomRowFilter -= GridView_CustomRowFilter;
        }

        private void SubscribeEvents()
        {
            GridView.CustomRowFilter += GridView_CustomRowFilter;
        }

        public bool IsRowInvisible(int dataSourceRowIndex)
        {
            return InvisibleRows.Contains(dataSourceRowIndex);
        }

        void GridView_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            if (IsRowInvisible(e.ListSourceRow))
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        public void HideRow(int dataSourceRowIndex)
        {
            if (!IsRowInvisible(dataSourceRowIndex))
                InvisibleRows.Add(dataSourceRowIndex);
            GridView.RefreshData();
        }

        public void ShowRow(int dataSourceRowIndex)
        {
            if (IsRowInvisible(dataSourceRowIndex))
                InvisibleRows.Remove(dataSourceRowIndex);
            GridView.RefreshData();
        }

        public void ToggleRowVisibility(int dataSourceRowIndex)
        {
            if (IsRowInvisible(dataSourceRowIndex))
                ShowRow(dataSourceRowIndex);
            else
                HideRow(dataSourceRowIndex);
        }

    }
}