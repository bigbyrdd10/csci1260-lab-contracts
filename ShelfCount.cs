using System;

public class ShelfCount : IEquatable<ShelfCount>, IComparable<ShelfCount>
{
    private readonly string student = string.Empty;
    private int assignmentNumber;
    private double score;

    public string Student
    {
        get { return student; }
    }

    public int AssignmentNumber
    {
        get { return assignmentNumber; }
    }

    public double Score
    {
        get { return score; }
    }

    public ShelfCount(string student, int assignmentNumber, double score)
    {
        if (string.IsNullOrWhiteSpace(student))
            throw new ArgumentException("Student name cannot be null or whitespace.", nameof(student));

        this.student = student.Trim();
        this.assignmentNumber = assignmentNumber;
        this.score = score;
    }

    public bool Equals(ShelfCount? other)
    {
        if (other == null)
            return false;

        return student == other.student &&
               assignmentNumber == other.assignmentNumber;
    }

    public override bool Equals(object? obj)
    {
        return obj is ShelfCount other && Equals(other);
    }

    public override int GetHashCode()
    {
        return student.GetHashCode() ^ assignmentNumber.GetHashCode();
    }

    public int CompareTo(ShelfCount? other)
    {
        if (other == null)
            return 1;

        int result = student.CompareTo(other.student);

        if (result != 0)
            return result;

        return assignmentNumber.CompareTo(other.assignmentNumber);
    }

    public override string ToString()
    {
        return string.Format("{0} #{1} {2:F2}",
            student,
            assignmentNumber,
            score);
    }
}
