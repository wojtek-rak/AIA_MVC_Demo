using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_MVC_Demo.Models
{
    public class GithubResultModel
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("clone_url")]
        public string CloneUrl { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("open_issues_count")]
        public string OpenIssuesCount { get; set; }
        [JsonProperty("watchers")]
        public string Watchers { get; set; }
    }
}
