using AngleSharp.Html.Dom;
using System.Threading;
using System.Threading.Tasks;

namespace ParserLib.Interface
{
    public interface IParser
    {
        Task Parse(IHtmlDocument document, CancellationToken cancelTokenSource);
        int GetNumberStartPage(IHtmlDocument document);
        int GetNumberLastPage(IHtmlDocument document);
    }
}
