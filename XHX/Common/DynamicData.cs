using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX.Common
{
    [Serializable]
    public abstract class DynamicData
    {
        protected object _value = null;
        public virtual object Value
        {
            get { return _value; }
            set
            {
                if (_value != null)
                {
                    if (_value.Equals(value) == false) this.IsChanged = true;
                }
                else if (value != null) this.IsChanged = true;
                _value = value;
            }
        }

        protected internal virtual bool IsChanged { get; set; }
        protected internal virtual bool IsDeleted { get; set; }

        public abstract bool IsSameRow(BufferColumnDto dto);
        public abstract DynamicData CopyKeyMembers(DynamicData data);      

        internal abstract string UniqueName { get; }
    }

    [Serializable]
    public abstract class OneLevelColumnData : DynamicData
    {
        public virtual string Column { get; set; }

        internal override string UniqueName
        {
            get { return DynamicColumnInfo.MakeUniqueName(Column); }
        }
    }

    [Serializable]
    public abstract class TwoLevelColumnData : DynamicData
    {
        public virtual string Column1 { get; set; }
        public virtual string Column2 { get; set; }

        internal override string UniqueName
        {
            get { return DynamicColumnInfo.MakeUniqueName(Column1, Column2); }
        }
    }
}
