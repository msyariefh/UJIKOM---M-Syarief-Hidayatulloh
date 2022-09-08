using System.Collections.Generic;

namespace Quiz.Global
{
    public class LevelComparer : IEqualityComparer<LevelStruct>
    {
        public bool Equals(LevelStruct x, LevelStruct y)
        {
            return x.PackID == y.PackID;
        }

        public int GetHashCode(LevelStruct obj)
        {
            return obj.PackID.GetHashCode();
        }
    }

}

