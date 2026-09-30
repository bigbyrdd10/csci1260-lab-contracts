using System;
using System.IO;

public class CountLog : IDisposable
{
    private StreamWriter? _writer;
    private int linesWritten;
    private bool closed;

    public bool Closed => closed;
    public int LinesWritten => linesWritten;

    public CountLog(string fileName)
    {
        _writer = new StreamWriter(fileName);
        _writer.WriteLine("LOG OPENED");
    }

    public void Write(ShelfCount record)
    {
        if (_writer is null)
            throw new ObjectDisposedException(nameof(CountLog));

        linesWritten++;
        _writer.WriteLine($"{linesWritten} {record}");
    }

    public void Dispose()
    {
        if (closed)
            return;

        if (_writer is null)
        {
            closed = true;
            return;
        }

        _writer.WriteLine($"LOG CLOSED, {linesWritten} lines written");
        _writer.Close();
        _writer = null;

        closed = true;
    }
}
