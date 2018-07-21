using Newtonsoft.Json;
using System.Collections.Generic;

namespace CharadesLibrary.Types
{
    public class Continue
    {
        public string Rncontinue { get; set; }
        [JsonProperty(PropertyName = "Continue")]
        public string InnerContinue { get; set; }

    }

    public class Query
    {
        public IList<Random> Random { get; set; }
    }

    public class Random
    {
        public int Id { get; set; }
        public string Ns { get; set; }
        public string Title { get; set; }
    }

    public class WikiResponse
    {
        public string BatchComplete { get; set; }
        public Continue Continue { get; set; }
        public Query Query { get; set; }
    }
}