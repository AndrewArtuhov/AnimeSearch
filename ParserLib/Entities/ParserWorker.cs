using AngleSharp.Html.Parser;
using ParserLib.Interface;

namespace ParserLib.Entities
{
    public class ParserWorker
    {
        private IParser _parser;
        private IParserSettings _settings;
        private HTMLLoader _loader;

        #region Properties

        public IParser Parser
        {
            get { return _parser; }
            set { _parser = value; }
        }
        public IParserSettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        #endregion

        public ParserWorker(IParser parser, IParserSettings settings) 
        {
            _parser = parser;
            _settings = settings;
            _loader = new HTMLLoader(_settings);
        }

        public async Task Start()
        {
            await Worker();
        }

        private async Task Worker()
        {
            var source = Task.Run(() => _loader.GetSourceByPageId(1, true)).Result;
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source); 

            _settings.StartPoint = _parser.GetNumberStartPage(document);
            _settings.EndPoint = _parser.GetNumberLastPage(document);
            for (int i = _settings.StartPoint; i <= _settings.EndPoint; i++)
            {
                source = Task.Run(() => _loader.GetSourceByPageId(i)).Result;
                document = await domParser.ParseDocumentAsync(source);
                await _parser.Parse(document, _settings.CancellationToken);
            }
        }
    }
}
