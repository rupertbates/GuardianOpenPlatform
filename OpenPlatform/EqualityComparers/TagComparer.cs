using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform.EqualityComparers
{
    public class TagComparer : IEqualityComparer<Tag>
    {
        #region IEqualityComparer<Tag> Members

        public bool Equals(Tag x, Tag y)
        {
            return x.Filter == y.Filter;
        }

        public int GetHashCode(Tag obj)
        {
            return obj.Filter.GetHashCode();
        }

        #endregion
    }
}
