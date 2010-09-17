using System;

namespace Guardian.OpenPlatform.Results.Entities
{
    public abstract class ContentBase : IEquatable<ContentBase>
    {
        public string Id { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public string ApiUrl { get; set; }

        #region Equality stuff
        public override bool Equals(object obj)
        {
            return Id == ((ContentBase)obj).Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool Equals(ContentBase other)
        {
            return Id == other.Id;
        }

        #endregion
    }
}
