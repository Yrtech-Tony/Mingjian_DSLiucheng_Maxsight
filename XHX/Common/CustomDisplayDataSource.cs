using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHX
{
    public class CustomDisplayDataSource : ICustomFormatter, IFormatProvider, System.Collections.ICollection
    {
        IList<CustomDisplayObject> _items = null;

        public IFormatProvider FormatProvider
        {
            get { return this; }
        }

        public CustomDisplayDataSource()
        {
            _items = new List<CustomDisplayObject>();
        }

        public void AddItem(object value, string text)
        {
            _items.Add(new CustomDisplayObject(value, text));
        }

        public CustomDisplayObject Find(object value)
        {
            return ((List<CustomDisplayObject>)_items).Find(
                delegate(CustomDisplayObject obj) { return obj.Equals(value); }
            );

        }

        #region IFormatProvider Members

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        #endregion

        #region ICustomFormatter Members

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null) return null;

            CustomDisplayObject obj = Find(arg);
            if (obj == null) return null;
            return obj.ToString();
        }

        #endregion


        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        #region IEnumerable Members

        public System.Collections.IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion
    }
}
