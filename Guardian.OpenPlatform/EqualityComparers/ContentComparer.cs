using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;

namespace Guardian.OpenPlatform.EqualityComparers
{
    public class ContentComparer : IEqualityComparer<Content>
    {
        #region IEqualityComparer<Content> Members

        public bool Equals(Content x, Content y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Content obj)
        {
            return obj.Id.GetHashCode();
        }

        #endregion
    }
}
