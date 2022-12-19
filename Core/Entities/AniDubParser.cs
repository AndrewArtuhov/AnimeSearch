using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands.CreateAnime;
using System.Threading;
using ParserLib.Interface;

namespace Core.Entities
{
    public class AniDubParser : IParser
    {
        private readonly IMediator _mediator;

        public AniDubParser(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Parse(IHtmlDocument document, CancellationToken cancelTokenSource)
        {
            var animeList = GetElementsHTML(document, "div", "kino-item ignore-select");
            var result = new List<Anime>();

            foreach (var item in animeList)
            {
                CreateAnimeCommand animeComan = new CreateAnimeCommand();
                //TODO переделать получение данных
                string name = GetItem(item, "a", "kino-h").ToString();
                if (animeComan.Name is null) continue;
                animeComan.Name = name;
                animeComan.Description = GetItem(item, "div", "kino-desc clearfix").ToString();
                animeComan.Rating = GetItem(item, "li", "current-rating").ToString();
                //
                await _mediator.Send(animeComan, cancelTokenSource);
            }

            return;
        }

        private IEnumerable<IElement> GetElementsHTML(IHtmlDocument document, string selector, string className)
        {
            return document.QuerySelectorAll(selector)
                           .Where(x => x.ClassName != null && x.ClassName.Contains(className));
        }

        private IElement GetItem(IElement element, string selector, string className)
        {
            return element.QuerySelectorAll(selector)
                          .Where(x => x.ClassName != null && x.ClassName.Contains(className))
                          .FirstOrDefault();
        }

        public int GetNumberStartPage(IHtmlDocument document)
        {
            return GetListPage(document).Min();
        }

        public int GetNumberLastPage(IHtmlDocument document)
        {
            return GetListPage(document).Max();
        }

        private List<int> GetListPage(IHtmlDocument document)
        {
            var pageNumbers = GetElementsHTML(document, "div", "pagi-nav clearfix ignore-select").FirstOrDefault();

            var result = new List<int>();

            foreach (var pageNumber in pageNumbers.TextContent.Split(' '))
            {
                if (int.TryParse(pageNumber, out int number))
                    result.Add(number);
            }
            return result;
        }
    }
}
