using System.Collections.Generic;

public class HighestValueFirst : IComparer<ShelfCount>
{
    public int Compare(ShelfCount? x, ShelfCount? y)
    {
        if (ReferenceEquals(x, y))
            return 0;

        if (x is null)
            return 1;

        if (y is null)
            return -1;

        int result = y.Score.CompareTo(x.Score);

        if (result != 0)
            return result;

        return ((IComparable<ShelfCount>)x).CompareTo(y);
    }
}
