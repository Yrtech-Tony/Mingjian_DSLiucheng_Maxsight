using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.Common
{
    [Serializable]
    public abstract class DynamicColumnInfo
    {
        public const string UNIQUE_NAME_PREFIX = "|";
        public const string UNIQUE_NAME_POSTFIX = "|";
        public const string UNIQUE_NAME_DELIMITER = "|";

        public static string MakeUniqueName(params string[] columnNames)
        {
            if (columnNames == null || columnNames.Length == 0) throw new IndexOutOfRangeException("Column name should be exist more than one.");
            StringBuilder sb = new StringBuilder();
            sb.Append(UNIQUE_NAME_PREFIX);
            foreach (string columnName in columnNames)
            {
                sb.Append(columnName);
                sb.Append(UNIQUE_NAME_DELIMITER);
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(UNIQUE_NAME_POSTFIX);
            return sb.ToString();
        }

        public virtual int Order { get; set; }
        public abstract string UniqueName { get; }
    }

    [Serializable]
    public class OneLevelColumnInfo : DynamicColumnInfo
    {
        public virtual string Column { get; set; }
        public virtual string Caption { get; set; }

        public override string UniqueName
        {
            get { return DynamicColumnInfo.MakeUniqueName(Column); }
        }
    }

    [Serializable]
    public class TwoLevelColumnInfo : DynamicColumnInfo
    {
        public virtual string Column1 { get; set; }
        public virtual string Column2 { get; set; }
        public virtual string Caption1 { get; set; }
        public virtual string Caption2 { get; set; }

        public override string UniqueName
        {
            get { return DynamicColumnInfo.MakeUniqueName(Column1, Column2); }
        }
    }

}
