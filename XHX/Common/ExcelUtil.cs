using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XHX.DTO;
using System.IO;

namespace XHX.Common
{
    public static class ExcelUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelStream"></param>
        /// <param name="subjectDtoList"></param>
        /// <param name="shopSubjectScoreDtoList"></param>
        public static void ImportShopSubjectScore(MemoryStream excelStream, out List<SubjectDto> subjectDtoList, out List<ShopSubjectScoreDto> shopSubjectScoreDtoList)
        {
            subjectDtoList = new List<SubjectDto>();
            shopSubjectScoreDtoList = new List<ShopSubjectScoreDto>();

            excelStream.Position = 0;
            Infragistics.Excel.Workbook workbook = Infragistics.Excel.Workbook.Load(excelStream);
            excelStream.Close();
            Infragistics.Excel.Worksheet ws = workbook.Worksheets[0];

            int rowIndex = 1;
            foreach (Infragistics.Excel.WorksheetRow row in ws.Rows)
            {
                if (rowIndex != 1)
                {
                    SubjectDto subjectDto = new SubjectDto();
                    subjectDto.LinkCode = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                    subjectDto.SubjectCode = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    subjectDto.CheckPoint = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                   
                    subjectDtoList.Add(subjectDto);

                    for (int colIndex = 0; colIndex < row.Cells.Count(); colIndex++)
                    {
                        if (colIndex > 2)
                        {
                            ShopSubjectScoreDto shopSubjectScoreDto = new ShopSubjectScoreDto();
                            shopSubjectScoreDto.ShopCode = ws.Rows[0].Cells[colIndex].Value == null ? "" : ws.Rows[0].Cells[colIndex].Value.ToString();
                            shopSubjectScoreDto.SubjectCode = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                            shopSubjectScoreDto.Score = row.Cells[colIndex].Value == null ? "" : row.Cells[colIndex].Value.ToString();
                            shopSubjectScoreDtoList.Add(shopSubjectScoreDto);
                        }
                    }
                }

                rowIndex++;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelStream"></param>
        /// <param name="ffvRateList"></param>
        /// <param name="shopFfvRateList"></param>
        public static void ImportFFVRate(MemoryStream excelStream, out List<FFVRateDto> ffvRateList, out List<FFVShopRateDto> shopFfvRateList)
        {
            ffvRateList = new List<FFVRateDto>();
            shopFfvRateList = new List<FFVShopRateDto>();

            excelStream.Position = 0;
            Infragistics.Excel.Workbook workbook = Infragistics.Excel.Workbook.Load(excelStream);
            excelStream.Close();
            Infragistics.Excel.Worksheet ws = workbook.Worksheets[0];
            Infragistics.Excel.Worksheet ws1 = workbook.Worksheets[1];

            int rowIndex = 1;
            foreach (Infragistics.Excel.WorksheetRow row in ws.Rows)
            {
                if (rowIndex != 1)
                {
                    FFVRateDto ffvRate = new FFVRateDto();
                    ffvRate.AllRate = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                    ffvRate.EastRate = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    ffvRate.SouthRate = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                    ffvRate.WestRate = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                    ffvRate.NorthRate = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                    ffvRate.Weight = row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString();

                    ffvRateList.Add(ffvRate);

                }
                rowIndex++;
            }
            int rowIndex1 = 1;
            foreach (Infragistics.Excel.WorksheetRow row in ws1.Rows)
            {
                if (rowIndex1 != 1)
                {
                    FFVShopRateDto ffvShopRate = new FFVShopRateDto();
                    ffvShopRate.ShopCode = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                    ffvShopRate.Weight = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                    shopFfvRateList.Add(ffvShopRate);

                }
                rowIndex1++;

            }
        }
    }
}
