using ParserLib.Interface;
using System.Threading;

namespace Core.Entities
{
    public class AniDubSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "http://online.anidub.best";
        public string Prefix { get; set; } = "page/{CurrentId}/";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}
