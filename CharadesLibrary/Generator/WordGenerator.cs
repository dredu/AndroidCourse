using CharadesLibrary.Types;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CharadesLibrary.Generator
{
    public class WordGenerator
    {
        private string _serviceUri = "https://pl.wikipedia.org/w/api.php?action=query&list=random&format=json&rnnamespace=0&rnlimit=1";
        private readonly  HttpClient _httpClient;

        public WordGenerator()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetRandomWikiPage()
        {
            var wikiResponse = await _httpClient.GetAsync(_serviceUri);
            var responseJson = wikiResponse.Content.ReadAsStringAsync().Result;
            var jsonObject = JsonConvert.DeserializeObject<WikiResponse>(responseJson);

            var randomWord = jsonObject.Query?.Random?.FirstOrDefault() == null
                ? "No word was generated"
                : jsonObject.Query?.Random?.FirstOrDefault()?.Title;

            return randomWord;
        }
    }
}