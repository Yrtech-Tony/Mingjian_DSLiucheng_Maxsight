using System.Linq;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using Infragistics.Excel;



namespace XHX.Common
{
    public class XtraGridExcelExporter : XtraGridExcelExporterBase
    {
        public XtraGridExcelExporter(string fileName, GridView pGridView)
        {
            GridViewForExcel = pGridView;
        }

        public new int BindColumnCount //new Method for calculation MaxColumnCount.[Add By ZhangXiChun 2010-09-08]
        {
            get
            {
                int colCount = 0;
                foreach (GridColumn col in GridViewForExcel.Columns)
                {
                    if (col.Visible == true)
                        colCount++;
                }
                return colCount;
            }
        }

        protected override int HeaderRowCount
        {
            get
            {
                int maxBandRowCount = 0;
                if (GridViewForExcel is BandedGridView)
                    maxBandRowCount = GetBandRowCount(((BandedGridView)GridViewForExcel).Bands);//use new calculation MaxBandRowCount Method.[Modify By ZhangXiChun 2010-08-10]

                if (GridViewForExcel.OptionsView.ShowColumnHeaders == true)
                    return maxBandRowCount + 1;
                else return maxBandRowCount;
            }
        }

        //new Method for calculation MaxBandRowCount.[Add By ZhangXiChun 2010-08-09]
        private int GetBandRowCount(GridBandCollection bandCollection)
        {

            int maxRowCount = 0;
            foreach (GridBand band in bandCollection)
            {
                int bandRowCount = 1;
                if (band.HasChildren)
                {
                    bandRowCount += GetBandRowCount(band.Children);
                }
                if (maxRowCount < bandRowCount)
                    maxRowCount = bandRowCount;
            }
            return maxRowCount;
        }

        //public void ExportByInfra(int startCol, int startRow, string fileName)
        //{
        //    Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
        //    workbook.CellReferenceMode = CellReferenceMode.A1;
        //    Worksheet worksheet = workbook.Worksheets.Add(GridViewForExcel.Name);

        //    int x = startCol, originX, bandRowCount, headerRowCount;
        //    int y = 0;
        //    int rowCount = GridViewForExcel.DataRowCount;
        //    x = startCol;
        //    bandRowCount = 0;
        //    headerRowCount = GridViewForExcel.OptionsView.ShowColumnHeaders == true ? bandRowCount + 1 : bandRowCount;
        //    GridColumnCollection colCollection = GridViewForExcel.Columns;

        //    foreach (GridColumn col in colCollection)
        //    {
        //        if (col.Visible)
        //        {
        //            worksheet.Rows[startRow].Cells[x].Value = col.Caption;

        //            for (y = 0; y < rowCount; y++)
        //            {
        //                if (ExportCellsAsDisplayText == true && (!(GridViewForExcel.GetRowCellValue(y, col) is bool) || (col.ColumnEdit != null && col.ColumnEdit.GetType().Name == "RepositoryItemComboBox")))//if type of col's value is bool and editor is't cbo, then export cell value.[Add by ZhangXiChun 2010-12-03]
        //                {
        //                    if ((GridViewForExcel.GetRowCellValue(y, col)) is decimal || (GridViewForExcel.GetRowCellValue(y, col) is int))
        //                    {
        //                        if (GridViewForExcel.GetRowCellDisplayText(y, col).Contains('%'))
        //                        {
        //                            worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
        //                        }
        //                        else
        //                        {
        //                            worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
        //                    }
        //                }
        //                else
        //                {
        //                    worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col).ToString();
        //                }
        //            }

        //            //if (GridViewForExcel.OptionsView.ShowFooter == true)
        //            //{
        //            //    if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
        //            //    {
        //            //        // modi zhang.amei 2012-7-5 13:11:14 数字类型的不需要处理格式
        //            //        // XlsProvider.SetCellString(x, y + startRow + headerRowCount, col.SummaryText);
        //            //        if (col.SummaryItem.SummaryValue is int || col.SummaryItem.SummaryValue is decimal)
        //            //            XlsProvider.SetCellData(x, y + startRow + headerRowCount, col.SummaryItem.SummaryValue);
        //            //        else XlsProvider.SetCellString(x, y + startRow + headerRowCount, col.SummaryText);
        //            //    }
        //            //    XlsProvider.SetCellStyle(x, y + startRow + headerRowCount, GetColumnHeaderStyle());
        //            //}
        //            x++;
        //        }
        //    }

        //    /* modified by sun.zeyu 20130111 end */
        //    workbook.Save(fileName);
        //}

        public void Export(int startCol, int startRow, string fileName)
        {
            Workbook workbook = new Workbook(WorkbookFormat.Excel2007);
            workbook.CellReferenceMode = CellReferenceMode.A1;
            Worksheet worksheet = workbook.Worksheets.Add(GridViewForExcel.Name);

            int x = startCol, originX, bandRowCount, headerRowCount;
            int y = 0;
            int rowCount = GridViewForExcel.DataRowCount;

            if (GridViewForExcel is BandedGridView)
            {
                x = startCol;
                GridBandCollection bandCollection = ((BandedGridView)GridViewForExcel).Bands;
                bandRowCount = GetBandRowCount(bandCollection); //get MaxBandRowCount.[Add By ZhangXiChun 2010-08-09]
                headerRowCount = GridViewForExcel.OptionsView.ShowColumnHeaders == true ? bandRowCount + 1 : bandRowCount; //get HeaderRowCount.[Add By ZhangXiChun 2010-09-08]
                if (bandRowCount == 1) //if isn't multi-row band.[Add By ZhangXiChun 2010-08-09]
                {
                    if (((BandedGridView)GridViewForExcel).OptionsView.ShowBands == false)
                    {
                        bandRowCount = 0;
                        headerRowCount = headerRowCount - 1;
                    }
                    foreach (GridBand band in bandCollection)
                    {
                        if (band.ReallyVisible)
                        {
                            originX = x;
                            if (band.Visible && ((BandedGridView)GridViewForExcel).OptionsView.ShowBands)
                                worksheet.Rows[startRow].Cells[x].Value = band.Caption;

                            GridBandColumnCollection colCollection = band.Columns;
                            foreach (GridColumn col in colCollection)
                            {
                                if (col.Visible)
                                {
                                    if (GridViewForExcel.OptionsView.ShowColumnHeaders == true) //if ShowColumnHeaders.[Add By ZhangXiChun 2010-09-08]
                                    {
                                        worksheet.Rows[startRow + bandRowCount].Cells[x].Value = col.Caption ?? string.Empty;
                                    }

                                    for (y = 0; y < rowCount; y++)
                                    {
                                        if (ExportCellsAsDisplayText == true && (!(GridViewForExcel.GetRowCellValue(y, col) is bool) || (col.ColumnEdit != null && col.ColumnEdit.GetType().Name == "RepositoryItemComboBox")))//if type of col's value is bool and editor is't cbo, then export cell value.[Add by ZhangXiChun 2010-12-03]
                                        {
                                            if ((GridViewForExcel.GetRowCellValue(y, col)) is decimal || (GridViewForExcel.GetRowCellValue(y, col) is int))
                                            {
                                                if (GridViewForExcel.GetRowCellDisplayText(y, col).Contains('%'))
                                                {
                                                    worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                                                }
                                                else worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col);
                                            }
                                            worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                                        }
                                        else worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col).ToString();
                                    }

                                    if (GridViewForExcel.OptionsView.ShowFooter == true)
                                    {
                                        if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                                        {
                                            if (col.SummaryItem.SummaryValue is int || col.SummaryItem.SummaryValue is decimal)
                                            {
                                                if (col.SummaryText.Contains('%'))
                                                {
                                                    worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryText;
                                                }
                                                else
                                                {
                                                    worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryItem.SummaryValue;
                                                }
                                            }
                                            else worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryText;
                                        }
                                    }
                                    x++;
                                }
                            }
                            if (((BandedGridView)GridViewForExcel).OptionsView.ShowBands)
                            {
                                //XlsProvider.SetCellStyleAndUnion(originX, startRow, x - originX, bandRowCount, GetBandHeaderStyle());
                                worksheet.MergedCellsRegions.Add(startRow, originX, startRow + bandRowCount, x);
                            }
                        }
                    }
                }
                else //if is multi-row band.[Add By ZhangXiChun 2010-08-09]
                {
                    int floor = 0;
                    ExportForBand(x, y, startRow++, ((BandedGridView)GridViewForExcel).Bands, bandRowCount, floor, worksheet);
                }

                /* modified by sun.zeyu 20130111 end */
                workbook.Save(fileName);
            }
            else if (GridViewForExcel is GridView)
            {
                x = startCol;
                GridColumnCollection colCollection = GridViewForExcel.Columns;
                foreach (GridColumn col in colCollection)
                {
                    if (col.Visible)
                    {
                        worksheet.Rows[startRow].Cells[x].Value = col.Caption;
                        for (y = 0; y < rowCount; y++)
                        {
                            if (ExportCellsAsDisplayText == true && (!(GridViewForExcel.GetRowCellValue(y, col) is bool) || (col.ColumnEdit != null && col.ColumnEdit.GetType().Name == "RepositoryItemComboBox")))
                            {
                                if ((GridViewForExcel.GetRowCellValue(y, col)) is decimal || (GridViewForExcel.GetRowCellValue(y, col) is int))
                                {
                                    if (GridViewForExcel.GetRowCellDisplayText(y, col).Contains('%'))
                                    {
                                        worksheet.Rows[y + startRow + 1].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                                    }
                                    else worksheet.Rows[y + startRow + 1].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col);
                                }
                                else worksheet.Rows[y + startRow + 1].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                            }
                            else worksheet.Rows[y + startRow + 1].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col).ToString();
                        }

                        if (GridViewForExcel.OptionsView.ShowFooter == true)
                        {
                            if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                            {
                                if (col.SummaryItem.SummaryValue is int || col.SummaryItem.SummaryValue is decimal)
                                {
                                    if (col.SummaryText.Contains('%'))
                                    {
                                        worksheet.Rows[y + startRow + 1].Cells[x].Value = col.SummaryText;
                                    }
                                    else
                                    {
                                        worksheet.Rows[y + startRow + 1].Cells[x].Value = col.SummaryItem.SummaryValue;
                                    }
                                }
                                else worksheet.Rows[y + startRow + 1].Cells[x].Value = col.SummaryText;
                            }
                        }
                        x++;
                    }
                }

                /* modified by sun.zeyu 20130111 end */
                workbook.Save(fileName);
            }
        }

        //new export method for multi-row band.[Add By ZhangXiChun 2010-08-09]
        private int ExportForBand(int x, int y, int startRow, GridBandCollection bandCollection, int bandRowCount, int floor, Worksheet worksheet)
        {
            foreach (GridBand band in bandCollection)
            {
                if (band.ReallyVisible)
                {
                    int originX = x;
                    worksheet.Rows[startRow + floor].Cells[x].Value = band.Caption;
                    if (band.HasChildren)
                    {
                        x = ExportForBand(x, y, startRow, band.Children, bandRowCount, floor + 1, worksheet);
                        //TODO: XlsProvider.SetCellStyleAndUnion(originX, startRow + floor, x - originX, 1, GetBandHeaderStyle());
                        try
                        {
                            worksheet.MergedCellsRegions.Add(startRow + floor, originX, startRow + floor, x - 1);
                            worksheet.Rows[startRow + floor].Cells[originX].CellFormat.Alignment = HorizontalCellAlignment.Center;
                            worksheet.Rows[startRow + floor].Cells[originX].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                        }
                        catch (System.Exception)
                        {

                        }
                    }
                    else
                    {
                        int headerRowCount = GridViewForExcel.OptionsView.ShowColumnHeaders == true ? bandRowCount + 1 : bandRowCount;
                        foreach (GridColumn col in band.Columns)
                        {
                            if (col.Visible)
                            {
                                if (GridViewForExcel.OptionsView.ShowColumnHeaders == true)
                                {
                                    worksheet.Rows[startRow + bandRowCount].Cells[x].Value = col.Caption ?? string.Empty;
                                    headerRowCount++;
                                }

                                for (y = 0; y < GridViewForExcel.DataRowCount; y++)
                                {
                                    if (ExportCellsAsDisplayText == true && (!(GridViewForExcel.GetRowCellValue(y, col) is bool) || (col.ColumnEdit != null && col.ColumnEdit.GetType().Name == "RepositoryItemComboBox")))//if type of col's value is bool and editor isn't cbo, then export cell value.[Add by ZhangXiChun 2010-12-03]
                                    {
                                        if ((GridViewForExcel.GetRowCellValue(y, col)) is decimal || (GridViewForExcel.GetRowCellValue(y, col) is int))
                                        {
                                            if (GridViewForExcel.GetRowCellDisplayText(y, col).Contains('%'))
                                            {
                                                worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                                            }
                                            else worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col);
                                        }
                                        else worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellDisplayText(y, col).ToString();
                                    }
                                    worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = GridViewForExcel.GetRowCellValue(y, col) == null ? "" : GridViewForExcel.GetRowCellValue(y, col).ToString();

                                }

                                if (GridViewForExcel.OptionsView.ShowFooter == true)
                                {
                                    if (col.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                                    {
                                        if (col.SummaryItem.SummaryValue is int || col.SummaryItem.SummaryValue is decimal)
                                        {
                                            if (col.SummaryText.Contains('%'))
                                            {
                                                worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryText;
                                            }
                                            else
                                            {
                                                worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryItem.SummaryValue;
                                            }
                                        }
                                        worksheet.Rows[y + startRow + headerRowCount].Cells[x].Value = col.SummaryText;
                                    }
                                }
                                x++;
                            }
                        }
                        //TODO: XlsProvider.SetCellStyleAndUnion(originX, startRow + floor, x - originX, band.HasChildren ? 1 : (floor == 0 ? bandRowCount : bandRowCount - floor), GetBandHeaderStyle());
                        try
                        {
                            worksheet.MergedCellsRegions.Add(startRow + floor, originX, startRow + floor + (band.HasChildren ? 1 : (floor == 0 ? bandRowCount : bandRowCount - floor)) - 1, x - 1);
                            worksheet.Rows[startRow + floor].Cells[originX].CellFormat.Alignment = HorizontalCellAlignment.Center;
                            worksheet.Rows[startRow + floor].Cells[originX].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                        }
                        catch (System.Exception)
                        {

                        }
                    }
                }
            }

            return x;
        }
    }
}
