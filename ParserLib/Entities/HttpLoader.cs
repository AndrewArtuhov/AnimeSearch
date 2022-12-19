using ParserLib.Interface;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParserLib.Entities
{
    public class HTMLLoader
    {
        private readonly string _urlPage;
        private readonly string _baseUrl;

        public HTMLLoader(IParserSettings settings)
        {
            _baseUrl = settings.BaseUrl;
            _urlPage = $@"{settings.BaseUrl}/{settings.Prefix}";
        }

        public async Task<string> GetSourceByPageId(int id, bool isStartPage = false)
        {
            var currentUrl = isStartPage ? _baseUrl : _urlPage.Replace("{CurrentId}", id.ToString());
            string? source = null;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(currentUrl);

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    source = await response.Content.ReadAsStringAsync();
                }
            }
            return source;
        }
    }
}
