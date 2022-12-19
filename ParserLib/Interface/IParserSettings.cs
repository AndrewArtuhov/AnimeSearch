using System.Threading;

namespace ParserLib.Interface
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
        CancellationToken CancellationToken { get; set; }
    }
}
