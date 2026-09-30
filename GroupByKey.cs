using System.Collections.Generic;

public class GroupedByKey : IComparer<ShelfCount>
{
    public int Compare(ShelfCount? x, ShelfCount? y)
    {
        if (ReferenceEquals(x, y))
            return 0;

        if (x is null)
            return -1;

        if (y is null)
            return 1;

        int result = x.Student.CompareTo(y.Student);

        if (result != 0)
            return result;

        result = x.AssignmentNumber.CompareTo(y.AssignmentNumber);

        if (result != 0)
            return result;

        return x.Score.CompareTo(y.Score);
    }
}
