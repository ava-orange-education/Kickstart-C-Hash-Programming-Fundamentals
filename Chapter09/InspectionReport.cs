public class InspectionReport : IDisposable
{
    private StreamWriter _writer;

    public InspectionReport(string filePath)
    {
        _writer = new StreamWriter(filePath);
    }

    public void WriteReport(string content)
    {
        _writer.WriteLine(content);
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }
}
