using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraExport;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace XHX.Common
{
    public class XtraGridExcelExporterBase
    {
        private ExportXlsProvider _xlsProvider = null;
        private GridView _gridView = null;
        private bool _exportCellsAsDisplayText = true;

        #region added by seo_jungro 20100812

        protected ExportXlsProvider XlsProvider
        {
            get { return _xlsProvider; }
        }

        protected GridView GridViewForExcel
        {
            get { return _gridView; }
            set { _gridView = value; }
        }       

        #endregion

        public ExportCacheCellStyle DefaultCellStyle
        {
            get { return _xlsProvider.GetDefaultStyle(); }
            set { _xlsProvider.SetDefaultStyle(value); }
        }

        public bool ExportCellsAsDisplayText
        {
            get { return _exportCellsAsDisplayText; }
            set { _exportCellsAsDisplayText = value; }
        }

        public int BindRowCount
        {
            get
            {
                if (_gridView.OptionsView.ShowFooter == true)
                    return HeaderRowCount + _gridView.DataRowCount + 1;
                else return HeaderRowCount + _gridView.DataRowCount;
            }

        }

        public int BindColumnCount
        {
            get { return _gridView.Columns.Count; }
        }

        protected virtual int HeaderRowCount
        {
            get
            {
                int maxBandRowCount = 0;
                if (_gridView is BandedGridView)
                {

                    GridBandCollection bands = ((BandedGridView)_gridView).Bands;
                    foreach (GridBand band in bands)
                    {
                        if (band.RowCount > maxBandRowCount) maxBandRowCount = band.RowCount;
                    }
                }

                if (_gridView.OptionsView.ShowColumnHeaders == true)
                    return maxBandRowCount + 1;
                else return maxBandRowCount;
            }
        }

        public XtraGridExcelExporterBase() { }
        public XtraGridExcelExporterBase(string fileName, GridView pGridView)
        {
            _xlsProvider = new DevExpress.XtraExport.ExportXlsProvider(fileName);
            _gridView = pGridView;

            ExportCacheCellStyle cellStyle = _xlsProvider.GetDefaultStyle();
            cellStyle.BkColor = Color.White;
            cellStyle.TextAlignment = StringAlignment.Near;
            ExportCacheCellBorderStyle borderStyle = new ExportCacheCellBorderStyle();
            borderStyle.Color_ = Color.White;
            borderStyle.Width = 1;
            cellStyle.TopBorder = cellStyle.BottomBorder = cellStyle.LeftBorder = cellStyle.RightBorder = borderStyle;
            _xlsProvider.SetDefaultStyle(cellStyle);
        }

        public void SetRange(int width, int height)
        {
            _xlsProvider.SetRange(width, height, true);
        }

        public void SetCellString(int col, int row, string str)
        {
            _xlsProvider.SetCellString(col, row, str);
        }

        public void SetCellStyle(int col, int row, AppearanceObject appearance)
        {
            _xlsProvider.SetCellStyle(col, row, ConvertAppearanceToCellStyle(appearance));
        }

        public void Commit()
        {
            _xlsProvider.Commit();
        }

        public void Dispose()
        {
            _xlsProvider.Dispose();
        }

        public virtual void Export(int startCol, int startRow)
        {
            int x = startCol, originX;
            int y;
            int rowCount = _gridView.DataRowCount;
            if (_gridView is BandedGridView)
            {
                x = startCol;
                GridBandCollection bandCollection = ((BandedGridView)_gridView).Bands;
                foreach (GridBand band in bandCollection)
                {
                    if (band.ReallyVisible)
                    {
                        originX = x;
                        _xlsProvider.SetCellString(x, startRow, band.Caption);
                        GridBandColumnCollection colCollection = band.Columns;
                        foreach (GridColumn col in colCollection)
                        {
                            if (col.Visible)
                            {
                                _xlsProvider.SetCellString(x, startRow + band.RowCount, col.Caption??string.Empty);
                                //_xlsProvider.SetCellStyle(x, startRow + band.RowCount, ConvertAppearanceToCellStyle(col.AppearanceHeader));
                                _xlsProvider.SetCellStyle(x, startRow + band.RowCount, GetColumnHeaderStyle());

                                for (y = 0; y < rowCount; y++)
                                {
                                    if (_exportCellsAsDisplayText == true)
                                    {
                                        _xlsProvider.SetCellString(x, y + startRow + band.RowCount + 1, _gridView.GetRowCellDisplayText(y, col).ToString());
                                    }
                                    else _xlsProvider.SetCellString(x, y + startRow + band.RowCount + 1, _gridView.GetRowCellValue(y, col).ToString());

                                    _xlsProvider.SetCellStyle(x, y + startRow + band.RowCount + 1, ConvertAppearanceToCellStyle(col.AppearanceCell));
                                }

                                if (_gridView.OptionsView.ShowFooter == true)
                                {
                                    if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                                    {
                                        _xlsProvider.SetCellString(x, y + startRow + band.RowCount + 1, col.SummaryText);
                                    }
                                    //_xlsProvider.SetCellStyle(x, y + startRow + band.RowCount + 1, ConvertAppearanceToCellStyle(col.AppearanceHeader));
                                    _xlsProvider.SetCellStyle(x, y + startRow + band.RowCount + 1, GetColumnHeaderStyle());
                                }
                                x++;
                            }
                        }
                        //_xlsProvider.SetCellStyleAndUnion(originX, startRow, x - originX, band.RowCount, ConvertAppearanceToCellStyle(band.AppearanceHeader));
                        _xlsProvider.SetCellStyleAndUnion(originX, startRow, x - originX, band.RowCount, GetBandHeaderStyle());
                    }
                }
            }
            else if (_gridView is GridView)
            {
                x = startCol;
                GridColumnCollection colCollection = _gridView.Columns;
                foreach (GridColumn col in colCollection)
                {
                    if (col.Visible)
                    {
                        _xlsProvider.SetCellString(x, startRow, col.Caption);
                        //_xlsProvider.SetCellStyle(x, startRow, ConvertAppearanceToCellStyle(col.AppearanceHeader));
                        _xlsProvider.SetCellStyle(x, startRow, GetColumnHeaderStyle());
                        for (y = 0; y < rowCount; y++)
                        {
                            if (_exportCellsAsDisplayText == true)
                            {
                                _xlsProvider.SetCellString(x, y + startRow + 1, _gridView.GetRowCellDisplayText(y, col).ToString());
                            }
                            else _xlsProvider.SetCellString(x, y + startRow + 1, _gridView.GetRowCellValue(y, col).ToString());

                            _xlsProvider.SetCellStyle(x, y + startRow + 1, ConvertAppearanceToCellStyle(col.AppearanceCell));
                        }

                        if (_gridView.OptionsView.ShowFooter == true)
                        {
                            if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                            {
                                _xlsProvider.SetCellString(x, y + startRow + 1, col.SummaryText);
                            }
                            //_xlsProvider.SetCellStyle(x, y + startRow + 1, ConvertAppearanceToCellStyle(col.AppearanceHeader));
                            _xlsProvider.SetCellStyle(x, y + startRow + 1, GetColumnHeaderStyle());
                        }
                        x++;
                    }
                }
            }
        }

        public static ExportCacheCellStyle ConvertAppearanceToCellStyle(AppearanceObject ap)
        {
            ExportCacheCellStyle cellStyle = new ExportCacheCellStyle();
            cellStyle.BkColor = ap.BackColor2;
            cellStyle.FgColor = ap.ForeColor;

            switch (ap.TextOptions.HAlignment)
            {
                case HorzAlignment.Far: cellStyle.TextAlignment = StringAlignment.Far; break;
                case HorzAlignment.Near: cellStyle.TextAlignment = StringAlignment.Near; break;
                default: cellStyle.TextAlignment = StringAlignment.Center; break;
            }
            ExportCacheCellBorderStyle borderStyle = new ExportCacheCellBorderStyle();
            borderStyle.Color_ = Color.FromArgb(220, 210, 205);
            borderStyle.Width = 1;
            cellStyle.TopBorder = cellStyle.BottomBorder = cellStyle.LeftBorder = cellStyle.RightBorder = borderStyle;
            cellStyle.TextFont = ap.Font;
            return cellStyle;
        }

        public ExportCacheCellStyle GetBandHeaderStyle()
        {
            ExportCacheCellStyle cellStyle = DefaultCellStyle;
            cellStyle.BkColor = Color.FromArgb(236, 233, 216);
            cellStyle.TextAlignment = StringAlignment.Center;
            ExportCacheCellBorderStyle borderStyle = new ExportCacheCellBorderStyle();
            borderStyle.Color_ = Color.FromArgb(212, 208, 200);
            borderStyle.Width = 3;
            cellStyle.TopBorder = cellStyle.BottomBorder = cellStyle.LeftBorder = cellStyle.RightBorder = borderStyle;
            return cellStyle;
        }

        public ExportCacheCellStyle GetColumnHeaderStyle()
        {
            ExportCacheCellStyle cellStyle = DefaultCellStyle;
            cellStyle.BkColor = Color.FromArgb(245, 240, 220);
            cellStyle.TextAlignment = StringAlignment.Near;
            ExportCacheCellBorderStyle borderStyle = new ExportCacheCellBorderStyle();
            borderStyle.Color_ = Color.FromArgb(220, 210, 205);
            borderStyle.Width = 2;
            cellStyle.BottomBorder = cellStyle.LeftBorder = cellStyle.RightBorder = borderStyle;
            return cellStyle;
        }
    }
}
