using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XHX.Common
{
    public sealed class XtraGridDataHandler<T>
    {

        #region :. Init


        public XtraGridDataHandler()
        {
            totalList = new List<T>();
        }
        public XtraGridDataHandler(DevExpress.XtraGrid.Views.Grid.GridView pGridView)
            : this()
        {
            gridView = pGridView;
            gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(gridView_RowUpdated);
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView_CellValueChanged);
            gridView.DataSourceChanged += new EventHandler(gridView_DataSourceChanged);

        }
        /* Date : 2009-02-09
         * Creator : lee seon young
         * Summary : grid의 Datasource가 바뀌었을 경우 totallist(grid에 변화가 일어난 data를 담는 list)를 clear.
         */
        private void gridView_DataSourceChanged(object sender, EventArgs e)
        {
            this.totalList.Clear();
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            this.Update((T)(sender as DevExpress.XtraGrid.Views.Grid.GridView).GetRow(e.RowHandle));
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            this.Update((T)e.Row);
        }



        #endregion

        #region :. Member feild

        private const string PropertyName = StatusTypes.STATUS_PROPERTY_NAME;
        private List<T> totalList = null;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView = null;

        #endregion

        #region :. Property

        public List<T> DataList
        {
            get { return totalList; }
        }

        #endregion

        #region :. public Methods

        #region :. Clear
        public void Clear()
        {
            totalList.Clear();
        }
        #endregion

        #region :. AddRow
        public void AddRow(T entity)
        {
            if (gridView == null || gridView.GridControl == null) return;

            IList<T> list = gridView.GridControl.DataSource as IList<T>;
            if (list == null) list = new List<T>();

            list.Add(entity);
            gridView.GridControl.DataSource = list;
            gridView.RefreshData();

            this.Insert(entity);
        }
        #endregion

        #region :. DelRow //Modify by MengFanWei 2009/03/02
        public void DelRow()
        {
            if (gridView == null || gridView.GridControl == null) return;

            int[] rowIndexes = gridView.GetSelectedRows(); // 선택된 Row 모두 가져옴
            if (rowIndexes == null) return;
            IList<T> delList = new List<T>();

            foreach (int index in rowIndexes)
            {
                T entity = (T)gridView.GetRow(index);
                if (entity == null) continue;
                delList.Add(entity);
                gridView.DeleteRow(index);     // Delete selectrows from view
            }
            //gridView.DeleteSelectedRows();  // 한번에 선택된 Row 모두 삭제

            this.Delete(delList);
        }
        #endregion
        #region DelRowByCheck //Modify by MouJunSheng MengFanWei 2009/03/19
        bool chk;
        public void DelCheckedRow(DevExpress.XtraGrid.Columns.GridColumn gridColumn)
        {
            chk = false;
            gridView.CloseEditor();
            gridView.UpdateCurrentRow();
            if (gridView == null || gridView.GridControl == null) return;
            IList<T> delList = new List<T>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                object dd = gridView.GetRowCellValue(i, gridColumn);
                if (dd != null)
                {

                    if (gridView.GetRowCellValue(i, gridColumn).ToString() == "True")
                    {
                        T entity = (T)gridView.GetRow(i);
                        if (entity == null) continue;
                        delList.Add(entity);
                        gridView.DeleteRow(i);
                        i--;
                    }
                }
            }

            // Modify MouJunSheng  2009.03.19
            if (delList == null || delList.Count == 0)
            {
                //FormUtil.ShowMessage(FormUtil.MessageType.ALERT, FormUtil.MessageLevel.INFORMATION, "COM006");
                //MessageBox.Show("No Data Delete.");
                CommonHandler.ShowMessage(MessageType.Information, "请选择要删除的行");
                return;
            }
            this.Delete(delList);
        }



        #endregion
        #region :. Insert
        public void Insert(T insertType)
        {
            if (insertType == null) return;
            this.totalList.Add(insertType);
            ReflectorUtil<T>.SetValue(insertType, PropertyName, StatusTypes.INSERT);
        }
        #endregion

        #region :. Update
        public void Update(T updateType)
        {
            if (updateType == null) return;
            if (this.totalList.Contains(updateType))
            {
                char resultStatus = (char)ReflectorUtil<T>.GetValue(updateType, PropertyName);
                if (resultStatus == StatusTypes.INSERT || resultStatus == StatusTypes.UPDATE)
                    return;
            }

            //if (this.insertList.Contains(updateType) || this.updateList.Contains(updateType)) 
            //    return;

            this.totalList.Add(updateType);

            ReflectorUtil<T>.SetValue(updateType, PropertyName, StatusTypes.UPDATE);
        }
        #endregion

        #region :. Delete

        public void Delete(IList<T> deleteTypes)
        {
            foreach (T deleteType in deleteTypes)
            {
                this.Delete(deleteType);
            }
        }


        public void Delete(T deleteType)
        {
            if (deleteType == null) return;

            if (!totalList.Contains(deleteType))
            {
                totalList.Add(deleteType);
                ReflectorUtil<T>.SetValue(deleteType, PropertyName, StatusTypes.DELETE);
                return;
            }

            char resultStatus = (char)ReflectorUtil<T>.GetValue(deleteType, PropertyName);
            if (resultStatus == StatusTypes.INSERT)
            {
                totalList.Remove(deleteType);
            }
            else if (resultStatus == StatusTypes.UPDATE)
            {
                ReflectorUtil<T>.SetValue(deleteType, PropertyName, StatusTypes.DELETE);
            }
        }
        #endregion

        #endregion
    }
}
