using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.Common
{
    [Serializable]
    public class DynamicColumnDataSet<ColumnInfoType, DataType, DtoType>
        where ColumnInfoType : DynamicColumnInfo
        where DataType : DynamicData
        where DtoType : BufferColumnDto
    {
        public List<ColumnInfoType> ColumnInfoList { get; set; }
        public List<DataType> DataList { get; set; }
        public List<DtoType> DtoList { get; set; }

        public DynamicColumnDataSet() { }
        public DynamicColumnDataSet(List<ColumnInfoType> columnInfoList, List<DataType> dataList)
        {
            this.ColumnInfoList = columnInfoList;
            this.DataList = dataList;
        }
        public DynamicColumnDataSet(List<ColumnInfoType> columnInfoList, List<DataType> dataList, List<DtoType> dtoList)
            : this(columnInfoList, dataList)
        {
            this.DtoList = dtoList;
        }
    }
}
