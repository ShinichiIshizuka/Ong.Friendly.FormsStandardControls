using System.Collections.Generic;

namespace Ong.Friendly.FormsStandardControls.Generator.CreateDriver
{
    internal static class CollectionUtility
    {
        public static bool HasReference<T>(IEnumerable<T> mappedControls, T control)
        {
            foreach (var e in mappedControls)
            {
                if (ReferenceEquals(e, control)) return true;
            }
            return false;
        }
    }
}
