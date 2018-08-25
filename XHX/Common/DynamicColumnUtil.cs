using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XHX.Common
{
    public class DynamicColumnUtil
    {
        public static void SortDynamicColumnInfo<ColumnInfoType>(List<ColumnInfoType> columnInfoList)
            where ColumnInfoType : DynamicColumnInfo
        {
            columnInfoList.Sort(new Comparison<ColumnInfoType>(
                delegate(ColumnInfoType source, ColumnInfoType target)
                {
                    return source.Order - target.Order;
                }
                ));
        }

        public static List<DtoType> CombineDynamicColumnDto<ColumnInfoType, DataType, DtoType>(List<ColumnInfoType> columnInfoList, List<DataType> dataList, List<DtoType> dtoList)
            where ColumnInfoType : DynamicColumnInfo
            where DataType : DynamicData
            where DtoType : BufferColumnDto
        {
            Dictionary<string, int> columnOrderDic = new Dictionary<string, int>();
            foreach (ColumnInfoType columnInfo in columnInfoList)
            {
                columnOrderDic.Add(columnInfo.UniqueName, columnInfo.Order + 1);
            }

            DtoType tempDto = null;
            Dictionary<DtoType, DataType> dataKeyMemberDic = new Dictionary<DtoType, DataType>();
            foreach (DataType data in dataList)
            {
                if (columnOrderDic.ContainsKey(data.UniqueName) == false) continue;

                tempDto = dtoList.Find(new Predicate<DtoType>(
                    delegate(DtoType target)
                    {
                        return data.IsSameRow(target);
                    }
                ));

                if (tempDto != null)
                {
                    if (dataKeyMemberDic.ContainsKey(tempDto) == false) dataKeyMemberDic.Add(tempDto, data);// Modify By ZhangXiChun 2010-09-19
                    tempDto.SetDynamicData(columnOrderDic[data.UniqueName], data);
                }
            }

            FillEmptyCells<ColumnInfoType, DataType, DtoType>(dataKeyMemberDic, columnInfoList, dtoList);
            return dtoList;
        }

        private static void FillEmptyCells<ColumnInfoType, DataType, DtoType>(Dictionary<DtoType, DataType> dataKeyMemberDic, List<ColumnInfoType> columnInfoList, List<DtoType> dtoList)
            where ColumnInfoType : DynamicColumnInfo
            where DataType : DynamicData
            where DtoType : BufferColumnDto
        {
            DataType tempData;
            foreach (DtoType item in dtoList)
            {
                for (int i = 0; i < columnInfoList.Count; i++)
                {
                    if (item.GetDynamicData(columnInfoList[i].Order + 1) == null)
                    {
                        tempData = Activator.CreateInstance<DataType>();
                        tempData = (DataType)item.CopyKeyMembers(tempData);
                        tempData.Value = String.Empty;

                        if (columnInfoList[i] is OneLevelColumnInfo) (tempData as OneLevelColumnData).Column = (columnInfoList[i] as OneLevelColumnInfo).Column;
                        else if (columnInfoList[i] is TwoLevelColumnInfo)
                        {
                            (tempData as TwoLevelColumnData).Column1 = (columnInfoList[i] as TwoLevelColumnInfo).Column1;
                            (tempData as TwoLevelColumnData).Column2 = (columnInfoList[i] as TwoLevelColumnInfo).Column2;
                        }
                        else continue;

                        if (tempData != null) item.SetDynamicData(columnInfoList[i].Order + 1, tempData);
                    }
                }
            }
        }

        public static List<DtoType> CombineDynamicColumnDto<ColumnInfoType, DataType, DtoType>(List<ColumnInfoType> columnInfoList, List<DataType> dataList)
            where ColumnInfoType : DynamicColumnInfo
            where DataType : DynamicData
            where DtoType : BufferColumnDto
        {
            Dictionary<string, int> columnOrderDic = new Dictionary<string, int>();
            foreach (ColumnInfoType columnInfo in columnInfoList)
            {
                columnOrderDic.Add(columnInfo.UniqueName, columnInfo.Order + 1);
            }

            PropertyInfo[] dataProperties = typeof(DataType).GetProperties();
            PropertyInfo tempProperty = null;
            List<MatchedPropertyFair> matchedPropertyList = new List<MatchedPropertyFair>();
            foreach (PropertyInfo propInfo in dataProperties)
            {
                if (propInfo.CanRead == false) continue;

                tempProperty = typeof(DtoType).GetProperty(propInfo.Name, propInfo.PropertyType);
                if (tempProperty == null) continue;
                if (tempProperty.CanRead == false) continue;
                if (tempProperty.CanWrite == false) continue;

                matchedPropertyList.Add(new MatchedPropertyFair(propInfo, tempProperty));
            }

            DtoType tempDto = null;
            Dictionary<DtoType, DataType> dataKeyMemberDic = new Dictionary<DtoType, DataType>();
            List<DtoType> dtoList = new List<DtoType>();
            foreach (DataType data in dataList)
            {
                if (columnOrderDic.ContainsKey(data.UniqueName) == false) continue;

                tempDto = dtoList.Find(new Predicate<DtoType>(
                    delegate(DtoType target)
                    {
                        return data.IsSameRow(target);
                    }
                ));
                if (tempDto == null)
                {
                    tempDto = Activator.CreateInstance<DtoType>();
                    dtoList.Add(tempDto);
                }

                foreach (MatchedPropertyFair propFair in matchedPropertyList)
                {
                    propFair.DtoPropertyInfo.SetValue(tempDto, propFair.DataPropertyInfo.GetValue(data, null), null);
                }

                if (dataKeyMemberDic.ContainsKey(tempDto) == false) dataKeyMemberDic.Add(tempDto, data);
                tempDto.SetDynamicData(columnOrderDic[data.UniqueName], data);
            }
            FillEmptyCells<ColumnInfoType, DataType, DtoType>(dataKeyMemberDic, columnInfoList, dtoList);
            return dtoList;
        }

        public static List<DefaultDynamicColumnDto> CombineDynamicColumnDto(List<OneLevelColumnInfo> columnInfoList, List<DefaultDynamicData> dataList)
        {
            Dictionary<string, int> columnOrderDic = new Dictionary<string, int>();
            foreach (OneLevelColumnInfo columnInfo in columnInfoList)
            {
                columnOrderDic.Add(columnInfo.UniqueName, columnInfo.Order + 1);
            }

            DefaultDynamicColumnDto tempDto = null;
            List<DefaultDynamicColumnDto> dtoList = new List<DefaultDynamicColumnDto>();
            Dictionary<DefaultDynamicColumnDto, DefaultDynamicData> dataKeyMemberDic = new Dictionary<DefaultDynamicColumnDto, DefaultDynamicData>();
            foreach (DefaultDynamicData data in dataList)
            {
                if (columnOrderDic.ContainsKey(data.UniqueName) == false) continue;

                tempDto = dtoList.Find(new Predicate<DefaultDynamicColumnDto>(
                    delegate(DefaultDynamicColumnDto target)
                    {
                        return data.IsSameRow(target);
                    }
                ));

                if (tempDto == null)
                {
                    tempDto = Activator.CreateInstance<DefaultDynamicColumnDto>();
                    tempDto.RowCode = data.RowCode;
                    tempDto.RowName = data.RowName;
                    dtoList.Add(tempDto);
                }

                if (dataKeyMemberDic.ContainsKey(tempDto) == false) dataKeyMemberDic.Add(tempDto, data);
                tempDto.SetDynamicData(columnOrderDic[data.UniqueName], data);
            }
            FillEmptyCells<OneLevelColumnInfo, DefaultDynamicData, DefaultDynamicColumnDto>(dataKeyMemberDic, columnInfoList, dtoList);
            return dtoList;
        }

        # region Modify by seo_jungro 2010-06-25

        public static List<DefaultDynamicColumnDto> CombineDynamicColumnDto(List<TwoLevelColumnInfo> columnInfoList, List<TwoLevelDynamicData> dataList)
        {
            Dictionary<string, int> columnOrderDic = new Dictionary<string, int>();
            foreach (TwoLevelColumnInfo columnInfo in columnInfoList)
            {
                columnOrderDic.Add(columnInfo.UniqueName, columnInfo.Order + 1);
            }

            DefaultDynamicColumnDto tempDto = null;
            List<DefaultDynamicColumnDto> dtoList = new List<DefaultDynamicColumnDto>();
            Dictionary<DefaultDynamicColumnDto, TwoLevelDynamicData> dataKeyMemberDic = new Dictionary<DefaultDynamicColumnDto, TwoLevelDynamicData>();
            foreach (TwoLevelDynamicData data in dataList)
            {
                if (columnOrderDic.ContainsKey(data.UniqueName) == false) continue;

                tempDto = dtoList.Find(new Predicate<DefaultDynamicColumnDto>(
                    delegate(DefaultDynamicColumnDto target)
                    {
                        return data.IsSameRow(target);
                    }
                ));

                if (tempDto == null)
                {
                    tempDto = Activator.CreateInstance<DefaultDynamicColumnDto>();
                    tempDto.RowCode = data.RowCode;
                    tempDto.RowName = data.RowName;
                    dtoList.Add(tempDto);
                }

                if (dataKeyMemberDic.ContainsKey(tempDto) == false) dataKeyMemberDic.Add(tempDto, data);
                tempDto.SetDynamicData(columnOrderDic[data.UniqueName], data);
            }
            FillEmptyCells<TwoLevelColumnInfo, TwoLevelDynamicData, DefaultDynamicColumnDto>(dataKeyMemberDic, columnInfoList, dtoList);
            return dtoList;
        }

        //public static List<DefaultDynamicColumnDto> CombineDynamicColumnDto(List<TwoLevelColumnInfo> columnInfoList, List<DefaultDynamicData> dataList)
        //{
        //    Dictionary<string, int> columnOrderDic = new Dictionary<string, int>();
        //    foreach (TwoLevelColumnInfo columnInfo in columnInfoList)
        //    {
        //        columnOrderDic.Add(columnInfo.UniqueName, columnInfo.Order + 1);
        //    }

        //    DefaultDynamicColumnDto tempDto = null;
        //    List<DefaultDynamicColumnDto> dtoList = new List<DefaultDynamicColumnDto>();
        //    foreach (DefaultDynamicData data in dataList)
        //    {
        //        if (columnOrderDic.ContainsKey(data.UniqueName) == false) continue;

        //        tempDto = dtoList.Find(new Predicate<DefaultDynamicColumnDto>(
        //            delegate(DefaultDynamicColumnDto target)
        //            {
        //                return data.IsSameRow(target);
        //            }
        //        ));

        //        if (tempDto == null)
        //        {
        //            tempDto = Activator.CreateInstance<DefaultDynamicColumnDto>();
        //            tempDto.RowCode = data.RowCode;
        //            tempDto.RowName = data.RowName;
        //            dtoList.Add(tempDto);
        //        }

        //        tempDto.SetDynamicData(columnOrderDic[data.UniqueName], data);
        //    }
        //    return dtoList;
        //}

        # endregion

        private class MatchedPropertyFair
        {
            public PropertyInfo DataPropertyInfo { get; set; }
            public PropertyInfo DtoPropertyInfo { get; set; }

            public MatchedPropertyFair() { }
            public MatchedPropertyFair(PropertyInfo dataPropertyInfo, PropertyInfo dtoPropertyInfo)
            {
                this.DataPropertyInfo = dataPropertyInfo;
                this.DtoPropertyInfo = dtoPropertyInfo;
            }
        }
    }
}
